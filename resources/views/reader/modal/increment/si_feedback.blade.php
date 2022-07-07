<!-- Create Follow Up -->
<div class="modal fade show" id="si_feedback">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">Shift Incharge Feedback of : <span class="text-primary designer_name"></span></h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            {!! Form::open(['action'=>'ProductionTestController@si_feedback', 'method'=>'POST']) !!}
                <div class="modal-body">
                    <input type="hidden" name="si_increment_id" id="si_increment_id" value="">
                    <center><h4 id="error_field_exist" class="text-danger"></h4></center>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Quality') !!}
                                <select class="form-control quality" required name="quality" >
                                    <option value=""></option>
                                    <option value="A">A</option>
                                    <option value="B">B</option>
                                    <option value="C">C</option>
                                    <option value="D">D</option>
                                    <option value="E">E</option>
                                </select>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Interest') !!}
                                <select class="form-control interest" required name="interest" >
                                    <option value=""></option>
                                    <option value="A">A</option>
                                    <option value="B">B</option>
                                    <option value="C">C</option>
                                    <option value="D">D</option>
                                    <option value="E">E</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Discipline') !!}
                                <select class="form-control discipline" required name="discipline" >
                                    <option value=""></option>
                                    <option value="A">A</option>
                                    <option value="B">B</option>
                                    <option value="C">C</option>
                                    <option value="D">D</option>
                                    <option value="E">E</option>
                                </select>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                {!! Form::label('Dedication') !!}
                                <select class="form-control dedication" required name="dedication" >
                                    <option value=""></option>
                                    <option value="A">A</option>
                                    <option value="B">B</option>
                                    <option value="C">C</option>
                                    <option value="D">D</option>
                                    <option value="E">E</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="col">
                            <h6>A = Excellent, B = Very Good, C = Good,</h6>
                            <h6>D = Average, E = Below Average</h6>
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
