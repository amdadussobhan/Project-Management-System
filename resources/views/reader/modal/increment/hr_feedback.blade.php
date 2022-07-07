<!-- Create Follow Up -->
<div class="modal fade show" id="hr_feedback">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">HR Feedback of : <span class="text-primary name"></span></h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            {!! Form::open(['action'=>'ProductionTestController@hr_feedback', 'method'=>'POST']) !!}
                <div class="modal-body">
                    <input type="hidden" name="hr_increment_id" id="hr_increment_id" value="">
                    <center><h4 id="error_field_exist" class="text-danger"></h4></center>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Joining Date') !!}
                                <input type="date" name="date" value="" class="form-control text-center joining_date">
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Attendence') !!}
                                {!! Form::text('attendence', null, ['class'=>'form-control text-center attendence', 'required']) !!}
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Current Salary') !!}
                                {!! Form::text('salary', null, ['class'=>'form-control text-center salary']) !!}
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Increment Suggest') !!}
                                {!! Form::text('amount', null, ['class'=>'form-control text-center amount', 'required']) !!}
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Remarks') !!}
                                {!! Form::textarea('remarks', null, ['class'=>'form-control text-center remarks', 'rows'=>'3']) !!}
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger float-left" data-dismiss="modal" style="width: 150px">Close</button>
                    <button type="submit" id="submit_lead" class="btn btn-success float-right" style="width: 150px">Save</button>
                </div>
            {!! Form::close() !!}
        </div>
    </div>
</div>
