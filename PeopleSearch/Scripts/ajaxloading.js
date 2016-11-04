$(function()
{

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options =
            {
                url: $form.attr("action"),
                type: $form.attr("method"),
                data: $form.serialize()
            };

        $.ajax(options).done(function (data)
          {
            var $target = $($form.attr("data-people-target"))
            $target.replaceWith(data)
        });
        return false;
        
    };

    var createAutocomplete = function () {
        var $input = $(this)
        var options = {
            source: $input.attr("data-people-autocomplete")
        };
        $input.autocomplete(options);
    }
    $("form[data-people-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-people-autocomplete]").each(createAutocomplete);

});



$body = $("body");

$(document).on({
    ajaxStart: function () { $body.addClass("loading"); },
    ajaxStop: function () { $body.removeClass("loading"); }
});