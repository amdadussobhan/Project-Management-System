@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing WorkOrder</h3>
@endsection

@section('content')
    <div class="container">
        @include('accounts.menu.main_menu')

        <div class="row">
            <div class="col-9 mb-2">
                <form class="form-inline justify-content-end" action="" method="GET">
                    <label class="px-2">Client : </label>
                    <select class="form-control" style="width: 130px" name="client">
                        <option value=""></option>
                        @foreach($clients as $client)
                            <option value="{{ $client->Client }}"> {{ $client->Client }} </option>
                        @endforeach
                    </select>

                    <label class="px-2">Month :</label>
                    <input type="month" style="width: 175px" name="month" value="" class="form-control">

                    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>
                </form>
            </div>
            <div class="col mb-2">
                <ul class="nav nav-pills justify-content-end">
                    <li class="nav-item pr-1">
                        <a href="#" class="nav-link btn-outline-primary" data-toggle="modal" data-target="#create_modal">
                            <b>Create New</b>
                        </a>
                    </li>
                </ul>
            </div>
        </div>

        <table class="table table-bordered table-striped text-center table-sm">
            <thead>
                <th style="vertical-align:middle;">SL</th>
                <th style="vertical-align:middle;">Client Code</th>
                <th style="vertical-align:middle;">Company Name</th>
                <th style="vertical-align:middle;">Ref ID</th>
                <th style="vertical-align:middle;">Month</th>
                <th style="vertical-align:middle;">Total Files</th>
                <th style="vertical-align:middle;">Created</th>
            </thead>
            <?php $SL = 1; ?>
            @if($rows != null)
                @foreach($rows as $row)
                    <tr>
                        <td>{{$SL++}}</td>
                        <td>{{$row->skill_code}}</td>
                        <td><a href="/4/workorder/{{ $row->id }}">{{$row->name}}</td>
                        <td>{{$row->ref_id}}</td>

                        @if($row->month != null)
                            <td>{{ date('M-y', strtotime($row->month)) }}</td>
                        @else
                            <td></td>
                        @endif
                        
                        <td>{{$row->total_quantity}}</td>

                        @if($row->created_at != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->created_at)) }}</td>
                        @else
                            <td></td>
                        @endif
                    </tr>
                @endforeach
            @endif
        </table>
        @if($rows != null)
            <div class="row justify-content-center"> {{$rows->links()}}</div>
        @endif
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