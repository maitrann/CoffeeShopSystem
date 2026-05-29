# Security and Config Migration Notes

This note records the first cleanup pass for the old CoffeeShopSystem project. It intentionally does not copy the old secret values. Use git history or your local backups only if you need to compare old values, then rotate them before using the project again.

## What Changed

- API base URL is now centralized in `WebMVC_CoffeeShopSystem/Web.config` as `ApiBaseUrl`.
- MVC endpoint classes under `WebMVC_CoffeeShopSystem/BaseURL` now build URLs from `stringUrl.Build(...)`.
- PayPal, SMTP, Google OAuth, and the SQL connection string no longer contain real-looking committed secrets.
- Account and supplier password checks now use PBKDF2 hashes through `WebAPI_CoffeeShop/Utilities/PasswordHasher.cs`.
- Existing plain-text account and supplier passwords are accepted once and upgraded to a hash after successful login.
- Login cookies now set `HttpOnly`, `SameSite=Lax`, and `Secure` when the current request is HTTPS.
- Query parameters in account/supplier/product API calls are URL-encoded before calling the API.
- A smoke test script was added at `tools/smoke-tests/CoffeeShopSmokeTests.ps1`.

## Secret Inventory

Fill these values locally before running the app. Rotate any credential that was ever committed.

| Area | File | Key or location | New value to set |
| --- | --- | --- | --- |
| MVC calls API | `WebMVC_CoffeeShopSystem/Web.config` | `appSettings/ApiBaseUrl` | API site URL, usually `http://localhost:63566/` |
| PayPal sandbox | `WebMVC_CoffeeShopSystem/Web.config` | `paypal/settings/clientId` | Rotated PayPal client id |
| PayPal sandbox | `WebMVC_CoffeeShopSystem/Web.config` | `paypal/settings/clientSecret` | Rotated PayPal client secret |
| SMTP | `WebMVC_CoffeeShopSystem/Web.config` | `SmtpHost`, `SmtpPort`, `SmtpUseSsl` | SMTP connection settings |
| SMTP | `WebMVC_CoffeeShopSystem/Web.config` | `SmtpUsername`, `SmtpPassword` | Rotated SMTP account/app password |
| SMTP sender | `WebMVC_CoffeeShopSystem/Web.config` | `MailFromAddress`, `MailFromName` | Sender identity |
| SQL Server | `WebAPI_CoffeeShop/Web.config` | `CoffeeShopSystemEntities` | Local SQL Server connection string |
| Google OAuth | `WebAPI_CoffeeShop/Web.config` | `GoogleClientId`, `GoogleClientSecret`, `GoogleRedirectUrl` | Rotated Google OAuth settings |

## Local Setup Checklist

1. Restore or recreate the `coffee_shop_system` database.
2. Copy `WebAPI_CoffeeShop/ConnectionStrings.local.example.config` to `WebAPI_CoffeeShop/ConnectionStrings.local.config`, then replace `YOUR_SOMEE_PASSWORD` with the password from Somee.
3. Update `WebMVC_CoffeeShopSystem/Web.config` `ApiBaseUrl` to the Web API URL.
4. If using Google login, set the Google OAuth values and make sure the redirect URL matches the Google console.
5. If using PayPal checkout, set PayPal sandbox credentials.
6. If using seller registration email, set SMTP values.
7. Start the Web API project first, then the MVC project.

## Recreate Somee Schema From EDMX

If the hosted Somee database is empty and the original local database is not available, start with:

```text
docs/create_somee_schema_from_edmx.sql
```

This script was generated from `WebAPI_CoffeeShop/Utilities/CoffeeShopSystemModel.edmx`. It creates tables and foreign keys only. The EDMX references these stored procedures but does not contain their bodies, so export them from the original local DB if you need the blog comment flows:

- `dbo.Comment_MaxIndC`
- `dbo.Comment_MnC_Type`
- `dbo.Comment_SubC_Type`
- `dbo.GetCommentMain`
- `dbo.GetCommentSub`

After schema creation, seed enough data for product smoke tests with:

```text
docs/seed_minimal_somee_data.sql
```

Seeded product image paths point to existing MVC assets under `/Content/assets/images/products/shop/`.

## Smoke Test Commands

Run products smoke test:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\smoke-tests\CoffeeShopSmokeTests.ps1 -ApiBaseUrl "http://localhost:63566/"
```

Run product details smoke test:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\smoke-tests\CoffeeShopSmokeTests.ps1 -ApiBaseUrl "http://localhost:63566/" -ProductId 1
```

Run login smoke test:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\smoke-tests\CoffeeShopSmokeTests.ps1 -ApiBaseUrl "http://localhost:63566/" -LoginEmail "you@example.com" -LoginPassword "your-password"
```

## Password Migration Notes

The database schema allows `password` up to 500 characters, enough for the current PBKDF2 format:

```text
PBKDF2$100000$<base64-salt>$<base64-hash>
```

For normal account login and supplier login:

- If the stored password is already hashed, the code verifies the hash.
- If the stored password is plain text and matches the submitted password, the code immediately replaces it with a PBKDF2 hash.
- Google-created accounts that still use the historical `BLANK` marker are left compatible for now. A later pass should replace this with an explicit external-login table or provider column.

## Manual Verification

- Search for committed secrets:

```powershell
rg -n "password=|clientSecret|clientId|smtp.Authenticate|GOCSPX|localhost:63566|DESKTOP-BBVNKGM|user id=sa" WebAPI_CoffeeShop WebMVC_CoffeeShopSystem
```

- Confirm URL centralization:

```powershell
rg -n "http://localhost:63566" WebMVC_CoffeeShopSystem\BaseURL WebMVC_CoffeeShopSystem\CallRESTful
```

- Confirm password hashing code is used:

```powershell
rg -n "PasswordHasher" WebAPI_CoffeeShop
```

## Known Follow-Ups

- Move local secrets out of committed `Web.config` entirely using config transforms, ignored local config files, IIS environment variables, or deployment-time transforms.
- Replace GET login endpoints with POST bodies so passwords are not placed in URLs.
- Add anti-forgery validation for MVC form posts.
- Replace ad-hoc cookies with ASP.NET authentication middleware or a proper claims identity.
- Convert `CallRESTful` classes to async and reuse `HttpClient`.
