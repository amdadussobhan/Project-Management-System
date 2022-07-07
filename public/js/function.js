$(document).ready(function(){
    console.log('Ready');
    var code = '';

    $(document).on('click', 'ul li', function(){
        $(this).addClass('active').siblings().removeClass('active')
    })
    
    $('.client').on('change', function()
    {
        client($(this).val());
    });
    
    $('.month').on('change', function()
    {
        var months = ($(this).val());
        var year = months.split('-')[0];
        var month = months.split('-')[1];

        $('.ref_id').val("SSL/PPD/"+year+month+"/"+code);
    });

    function client(find) {
        $.ajaxSetup({
            headers: {'X-CSRF-Token': '{{ csrf_token() }}'}
        });

        $.ajax({
            url:'/client',
            method: "GET",
            data: { find:find },
            dataType: 'json',
            success:function (data) {
                $('.company_name').val(data.company_name);
                $('.address').val(data.address);
                code = data.sl;
                $('.code').val(code);
            }
        })
    };
    
    $(document).on("click", ".add_efficiency", function () {
        var name = $(this).data("name");
        var log_id = $(this).data("log_id");
        var increment_id = $(this).data("increment_id");

        $("#name").val(name);
        $("#log_id").val(log_id);
        $("#increment_id").val(increment_id);
    });

    $(document).on("click", ".edit_efficiency", function () {
        var production_test_id = $(this).data("production_test_id");
        var performance = $(this).data("performance");

        $("#production_test_id").val(production_test_id);
        $(".performance").val(performance);
    });

    $(document).on("click", ".si_feedback", function () {
        $("#si_increment_id").val($(this).data("si_increment_id"));
        $(".designer_name").text($(this).data("designer_name"));
        $(".quality").val($(this).data("quality"));
        $(".interest").val($(this).data("interest"));
        $(".discipline").val($(this).data("discipline"));
        $(".dedication").val($(this).data("dedication"));
    });

    $(document).on("click", ".increment", function () {
        $("#increment_id").val($(this).data("increment_id"));
        $(".name").text($(this).data("name"));
        $(".amount").val($(this).data("amount"));
        $(".remarks").val($(this).data("remarks"));
    });

    $(document).on("click", ".hr_feedback", function () {
        $("#hr_increment_id").val($(this).data("hr_increment_id"));
        $(".name").text($(this).data("name"));
        $(".amount").val($(this).data("amount"));
        $(".remarks").val($(this).data("remarks"));
        $(".salary").val($(this).data("salary"));
        $(".attendence").val($(this).data("attendence"));
        $(".department").val($(this).data("department"));
        $(".joining_date").val($(this).data("joining_date"));
    });
});