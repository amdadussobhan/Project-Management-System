<!-- Create Follow Up -->
<div class="modal fade show" id="increment">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                @if($user == "5")
                    <h4 class="modal-title">Increment Approval of : <span class="text-primary name"></span></h4>
                @else
                    <h4 class="modal-title">Increment Suggest of : <span class="text-primary name"></span></h4>
                @endif
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            {!! Form::open(['action'=>'ProductionTestController@increment', 'method'=>'POST']) !!}
                <div class="modal-body">
                    <input type="hidden" name="increment_id" id="increment_id" value="">
                    <center><h4 id="error_field_exist" class="text-danger"></h4></center>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Amount') !!}
                                {!! Form::text('amount', null, ['class'=>'form-control text-center amount', 'required'=>'required']) !!}
                            </div>

                            <div class="form-group">
                                {!! Form::label('Remarks') !!}
                                {!! Form::textarea('remarks', null, ['class'=>'form-control text-center remarks', 'placeholder'=>'comment anything if needed.', 'rows'=>'5']) !!}
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
