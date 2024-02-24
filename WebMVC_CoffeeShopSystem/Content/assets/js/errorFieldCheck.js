/**
 * errorFieldCheck is A Validate Class
 * It validate Fields Input With Passed Selector
 *  @author Vinh
 */

class errorFieldCheck {

    /**
     * Validate Space And Min Length Items
     * @param {*} current Items Need to Validate 
     * @param {*} itemError Items Alert Error Message
     * @returns boolean
     */
    checkEmptyFields(current, itemError) {
        var valueOfItem = $(current).val().trimStart().trimEnd();
        const minLength = $(current).attr('minlength');
        var lengthItem = valueOfItem.trim().length;
        var flagEmpty = true;
        $(itemError).attr('data-validate', false);
        if (lengthItem == 0) {
            $(itemError).text("Please Input This Field");
            flagEmpty = false;
        }
        else if (lengthItem < minLength) {
            $(itemError).text(`Please Input At Least ${minLength} Chacracters`);
            flagEmpty = false;
        }
        else {
            $(itemError).text("");
            $(itemError).attr('data-validate', true);
        }
        return flagEmpty;
    }

    /**
     * Validate Speacial Chacters Accept Space
     * @param {*} current Items Need to Validate 
     * @returns boolean
     */
    checkSpecialInputAcSpace(current) {
        var r = /[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi,
            v = $(current).val();
        if (r.test(v)) {
            $(current).val(v.replace(r, ''));
            return false;
        }
        return true;
    }

    /**
     * Validate Speacial Chacters None Accept Space
     * @param {*} current Items Need to Validate 
     * @returns boolean
     */
    checkSpecialInputDsSpace(current) {
        var r = /[^a-z0-9]/gi,
            v = $(current).val();
        if (r.test(v)) {
            $(current).val(v.replace(r, ''));
            return false;
        }
        return true;
    }

    /**
     * Validate Numbers 
     * @param {*} current Items Need to Validate 
     * @returns boolean
     */
    checkInputNumbers(current) {
            //var c = $(current)[0].selectionStart,
        var r = /[a-z `~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/$]/gi,
            v = $(current).val();
        if (r.test(v)) {
            $(current).val(v.replace(r, ''));
            return false;
        }
        return true;
    }

    /**
     * Validate Email
     * @param {*} current Items Need to Validate 
     * @param {*} itemError Items Alert Error Message
     * @returns boolean
     */
    checkInputEmail(current,itemError){
        var r = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
            v = $(current).val();
        $(itemError).attr('data-validate', false);
        if(!r.test(v)){
            $(itemError).text("Please Input Valid Email ex : abc@domain.com");
            return false;
        } else{
            $(itemError).text("");
            $(itemError).attr('data-validate', true);
        }
        return true;

    }

}