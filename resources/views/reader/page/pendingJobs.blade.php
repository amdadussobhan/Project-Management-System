@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Jobs List </h3>
@endsection
<?php
$role = Auth::User()->role;
$users = App\User::Where('role', 'admin')->orWhere('role', 'writer')->get();
?>
@section('content')
    <div class="container-fluid">
        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                </div>
            </div>
        </strong>

        <div class="row align-items-center">
            <div class="col mb-2">
                @include('reader.menu.left_menu')
            </div>

            <div class="col mb-2">
                @include('reader.menu.right_menu')
            </div>
        </div>

        <?php $isBlank = true; ?>

        @if( $basic->count() != 0)
            <h3 align="center"> Basic Team Pending Jobs </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Service</th>
                    <th>Input File</th>
                    <th>Output File</th>
                    <th>Target Time (avg)</th>
                    <th>Pro Time (avg)</th>
                    <th>Total Time</th>
                </thead>
                <?php $SL = 1; $TotalInput = 0; $TotalOutput = 0; $TotalLoad = 0; ?>
                @foreach($basic as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>

                        @if($row->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{$row->Service}}</td>

                        <td>{{$row->Input_File}}</td>
                        <?php $TotalInput += $row->Input_File ?>

                        <td>{{$row->Output_File}}</td>
                        <?php $TotalOutput += $row->Output_File ?>

                        <td>{{ Round($row->Target_Time, 1) }} </td>
                        <td>{{ Round($row->ProTime,1) }}</td>

                        <td>{{ Round($row->Total_Time,1) }}</td>
                        <?php  $TotalLoad += $row->Total_Time ?>
                    </tr>
                @endforeach
                <tr>
                        <td colspan="7" align="right"><b> Total Files--->  </b></td>
                        <td><b> {{ $TotalInput }} </b></td>
                        <td><b> {{ $TotalOutput }} </b></td>
                        <td colspan="2" align="right"><b> Total Workload --->  </b></td>
                        <td><b> {{ Round($TotalLoad) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if( $advance->count() != 0)
            <h3 align="center"> Advance Team Pending Jobs </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                <th>SL</th>
                <th>Job ID</th>
                <th>Folder</th>
                <th>Category</th>
                <th>Incoming</th>
                <th>Delivery</th>
                <th>Service</th>
                <th>Input File</th>
                <th>Output File</th>
                <th>Target Time (avg)</th>
                <th>Pro Time (avg)</th>
                <th>Total Time</th>
                </thead>
                <?php $SL = 1; $TotalInput = 0; $TotalOutput = 0; $TotalLoad = 0; ?>
                @foreach($advance as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>

                        @if($row->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{$row->Service}}</td>
                        <td>{{$row->Input_File}}</td>
                        <?php $TotalInput += $row->Input_File ?>

                        <td>{{$row->Output_File}}</td>
                        <?php $TotalOutput += $row->Output_File ?>

                        <td>{{ Round($row->Target_Time,1) }}</td>
                        <td>{{ Round($row->ProTime,1) }}</td>

                        <td>{{ Round($row->Total_Time,1) }}</td>
                        <?php $TotalLoad += $row->Total_Time ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="7" align="right"><b> Total Files--->  </b></td>
                    <td><b> {{ $TotalInput }} </b></td>
                    <td><b> {{ $TotalOutput }} </b></td>
                    <td colspan="2" align="right"><b> Total Workload --->  </b></td>
                    <td><b> {{ Round($TotalLoad) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if( $QC_Team->count() != 0)
            <h3 align="center"> QC Team Pending Jobs </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                <th>SL</th>
                <th>Job ID</th>
                <th>Folder</th>
                <th>Category</th>
                <th>Incoming</th>
                <th>Delivery</th>
                <th>Service</th>
                <th>Input File</th>
                <th>Output File</th>
                <th>Target Time (avg)</th>
                <th>Pro Time (avg)</th>
                <th>Total Time</th>
                </thead>
                <?php $SL = 1; $TotalInput = 0; $TotalOutput = 0; $TotalLoad = 0; ?>
                @foreach($QC_Team as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>

                        @if($row->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{$row->Service}}</td>
                        <td>{{$row->Input_File}}</td>
                        <?php $TotalInput += $row->Input_File ?>

                        <td>{{$row->Output_File}}</td>
                        <?php $TotalOutput += $row->Output_File ?>

                        <td>{{ Round($row->Target_Time,1) }}</td>
                        <td>{{ Round($row->ProTime,1) }}</td>

                        <td>{{ Round($row->Total_Time,1) }}</td>
                        <?php $TotalLoad += $row->Total_Time ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="7" align="right"><b> Total Files--->  </b></td>
                    <td><b> {{ $TotalInput }} </b></td>
                    <td><b> {{ $TotalOutput }} </b></td>
                    <td colspan="2" align="right"><b> Total Workload --->  </b></td>
                    <td><b> {{ Round($TotalLoad) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if($newJobs->count() != 0)
            <h3 align="center"> New Jobs Received (UnTouch) </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                <th>SL</th>
                <th>Job ID</th>
                <th>Folder</th>
                <th>Category</th>
                <th>Type</th>
                <th>Incoming</th>
                <th>Delivery</th>
                <th>Input File</th>
                <th>Target Time</th>
                <th>Total Time</th>
                <th>Receiver</th>
                </thead>
                <?php $SL = 1; $TotalInput = 0; $TotalLoad = 0; ?>
                @foreach($newJobs as $newJob)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$newJob->JobId}}">{{$newJob->JobId}}</td>
                        <td>{{$newJob->Folder}}</td>
                        <td>{{$newJob->Category}}</td>
                        <td>{{$newJob->Type}}</td>

                        @if($newJob->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($newJob->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($newJob->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($newJob->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{$newJob->InputAmount}}</td>
                        <?php $TotalInput += $newJob->InputAmount ?>

                        <td>{{ Round($newJob->ActualTime,1) }}</td>

                        <td>{{ Round(($newJob->ActualTime * $newJob->InputAmount) ,1)}}</td>
                        <?php $TotalLoad += $newJob->ActualTime * $newJob->InputAmount ?>

                        <td>{{ $newJob->Receiver}}</td>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="7" align="right"><b> Total Files--->  </b></td>
                    <td><b> {{ $TotalInput }} </b></td>
                    <td align="right"><b> Total Workload --->  </b></td>
                    <td><b> {{ Round($TotalLoad) }} </b></td>
                    <td></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        <br><br><br><br><br>

        @if($isBlank)
            <h3 align="center">There have no pending jobs, Everything was finished</h3>
        @endif

        <br><br><br><br><br>
    </div>
@endsection
