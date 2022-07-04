@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing WorkOrder</h3>
@endsection

@section('content')
    <div class="container">
        @include('accounts.menu.main_menu')
        
        <div class="text-center">
            <h1 class="mr-5 mt-4 ml-5">Work Order Summary</h1>
        </div>

        <div class="row mr-0 ml-3 mb-3 mt-3">
            <div class="col-2">
                <h5>Client Code : <br></h5>
                <h5>Client Name : <br></h5>
                <h5>Address : <br></h5>
                <h5>Ref ID : <br></h5>
            </div>

            <div class="col-7 m-0 p-0 float-left">
                <h5>{{ $workorder->skill_code }} <br></h5>
                <h5>{{ $workorder->name }} <br></h5>
                <h5>{{ $workorder->address }} <br></h5>
                <h5>{{ $workorder->ref_id }} <br></h5>
            </div>
            <div class="col-3 pr-0 mr-0">
                <br><br><br>
                <ul class="nav nav-pills float-right">
                    <a href="/4/print/workorder/{{ $workorder->id }}" target="_blank" class="nav-link btn btn-success mr-1"><b>Save & Print</b></a>
                    <a href="#" class="nav-link btn btn-primary" data-toggle="modal" data-target="#create_modal"><b>Create New</b></a>
                </ul>
            </div>
        </div>       

        <table class="table table-bordered table-striped text-center table-sm">
            <thead>                
                <th style="vertical-align:middle;">SL</th>
                <th style="vertical-align:middle;">Job ID</th>
                <th style="vertical-align:middle;">Folder Name</th>
                <th style="vertical-align:middle;">Service</th>
                <th style="vertical-align:middle;">Date</th>
                <th style="vertical-align:middle;">Qnt</th>
            </thead>

            <?php $SL = 1; ?>
            @if($rows != null)
                @foreach($rows as $row)
                    <tr>
                        <td>{{$SL++}}</td>
                        <td>{{$row->JobId}}</td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Service}}</td>

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{$row->OutputAmount}}</td>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="5" align="right"> <b>Grant Total File Quantity : </b> </td>
                    <td><b> {{ $TotalQnt }} </b></td>
                </tr>
            @endif
        </table>
        <br><br><br><br><br>
    </div>

    <div class="modal fade show" id="create_modal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Create Workorder</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                {!! Form::open(['action'=>'WorkorderController@store', 'method'=>'POST']) !!}
                    <div class="modal-body">
                    <input type="hidden" name="code" class="code" value="">
                        <center><h4 id="error_field_exist" class="text-danger"></h4></center>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    {!! Form::label('Client') !!}
                                    <select class="form-control client" name="client" required>
                                        <option value=""></option>
                                        @foreach($clients as $client)
                                            <option value="{{ $client->Client }}"> {{ $client->Client }} </option>
                                        @endforeach
                                    </select>
                                </div>
                            </div>

                            <div class="col">
                                <div class="form-group">
                                    {!! Form::label('Month') !!}
                                    {!! Form::month('month', null, ['class'=>'form-control month', 'required'=>'required']) !!}                                    
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    {!! Form::label('Company_Name') !!}
                                    {!! Form::text('company_name', null, ['class'=>'form-control company_name', 'required'=>'required']) !!}
                                </div>
                            </div>
                            <div class="col">
                                <div class="form-group">
                                    {!! Form::label('Ref ID') !!}
                                    {!! Form::text('ref_id', null, ['class'=>'form-control ref_id', 'required'=>'required']) !!}
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group ">
                                    {!! Form::label('Address') !!}
                                    {!! Form::text('address', null, ['class'=>'form-control address', 'required'=>'required']) !!}
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
@endsection