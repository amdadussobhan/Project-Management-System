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
    
    $(".add_efficiency").click(function () {
        var name = $(this).data("name");
        var log_id = $(this).data("log_id");
        var increment_id = $(this).data("increment_id");

        $("#name").val(name);
        $("#log_id").val(log_id);
        $("#increment_id").val(increment_id);
    });

    $(".edit_efficiency").click(function () {
        var production_test_id = $(this).data("production_test_id");
        var performance = $(this).data("performance");

        $("#production_test_id").val(production_test_id);
        $(".performance").val(performance);
    });

    $(".si_feedback").click(function () {
        var si_increment_id = $(this).data("si_increment_id");
        var designer_name = $(this).data("designer_name");

        $("#si_increment_id").val(si_increment_id);
        $(".designer_name").text(designer_name);
    });

    $(".increment").click(function () {
        var increment_id = $(this).data("increment_id");
        var name = $(this).data("name");
        var amount = $(this).data("amount");
        var remarks = $(this).data("remarks");

        $("#increment_id").val(increment_id);
        $(".name").text(name);
        $(".amount").val(amount);
        $(".remarks").val(remarks);
    });

    $(".hr_feedback").click(function () {
        var hr_increment_id = $(this).data("hr_increment_id");
        var name = $(this).data("name");
        var amount = $(this).data("amount");
        var remarks = $(this).data("remarks");
        var salary = $(this).data("salary");
        var attendence = $(this).data("attendence");
        var department = $(this).data("department");
        var date = $(this).data("date");

        $("#hr_increment_id").val(hr_increment_id);
        $(".name").text(name);
        $(".amount").val(amount);
        $(".remarks").val(remarks);
        $(".salary").val(salary);
        $(".attendence").val(attendence);
        $(".department").val(department);
        $(".date").val(date);
        console.log(date);
    });hr_feedback
});