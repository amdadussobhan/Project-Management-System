<!-- Create Follow Up -->
<div class="modal fade show" id="add_efficiency">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">Add Performance</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            {!! Form::open(['action'=>'ProductionTestController@add_efficiency', 'method'=>'POST']) !!}
                <div class="modal-body">
                    <input type="hidden" name="increment_id" id="increment_id" value="">
                    <input type="hidden" name="name" id="name" value="">
                    <input type="hidden" name="log_id" id="log_id" value="">
                    <center><h4 id="error_field_exist" class="text-danger"></h4></center>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Performance') !!}
                                {!! Form::text('performance', null, ['class'=>'form-control text-center', 'required'=>'required']) !!}
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
