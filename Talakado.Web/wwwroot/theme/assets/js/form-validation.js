$(document).ready(function() {
    $('#contact_form').bootstrapValidator({        
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            name: {
                validators: {
                        stringLength: {
                        min: 2,
                    },
                        notEmpty: {
                        message: 'لطفا نام کامل خود را وارد کنید'
                    }
                }
            },

            email: {
                validators: {
                    notEmpty: {
                        message: 'لطفا آدرس ایمیل خود را وارد کنید'
                    },
                    emailAddress: {
                        message: 'لطفا یک آدرس ایمیل معتبر وارد کنید'
                    }
                }
            },
            comment: {
                validators: {
                      stringLength: {
                        min: 10,
                        max: 200,
                        message:'لطفا حداقل 10 کاراکتر و بیشتر از 200 کاراکتر وارد کنید'
                    },
                    notEmpty: {
                        message: 'لطفا یک توضیح وارد کنید'
                    }
                    }
                }
            }
        }).on('success.form.bv', function(e) {           
            e.preventDefault();            
            var $form = $(e.target);            
            $.post($form.attr('action'), $form.serialize(), function(result) {                
				$("#message").html(result.message).addClass('show');
				$("#contact_form").find("input[type=text], input[type=email], textarea").val("");
            }, 'json');
        });
});