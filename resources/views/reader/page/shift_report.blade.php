@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Shift Report </h3>
@endsection
<?php
    $role = Auth::User()->role;
    $users = App\User::Where('role', 'admin')->orWhere('role', 'writer')->get();
?>

@section('content')
    <div class="container">
        <div class="row align-items-center">
            <div class="col mb-2">
                @include('reader.menu.left_menu')
            </div>

            <div class="col mb-2">
                @include('reader.menu.right_menu')
            </div>
        </div>
        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                    @include('reader.menu.filter_shift_report')
                </div>
            </div>
        </strong>

        <table class="table table-bordered table-striped text-center h5">
            <thead>
                <th>Total Workload</th>
                <th>Total Capacity</th>
                <th>QC Capacity</th>
                <th>Total Input</th>
                <th>Total Output</th>
                <th>QC Done</th>
                <th>Last 24 Input</th>
                <th>Last 24 Output</th>
            </thead>
            <tr>
                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->TotalLoad }}</td>
                @else
                    <td></td>
                @endif

                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->Capacity }}</td>
                @else
                    <td></td>
                @endif

                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->QC_Capacity }}</td>
                @else
                    <td></td>
                @endif

                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->TotalFile }}</td>
                @else
                    <td></td>
                @endif

                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->OutputFile }}</td>
                @else
                    <td></td>
                @endif

                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->QcDone }}</td>
                @else
                    <td></td>
                @endif

                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->Last24Input }}</td>
                @else
                    <td></td>
                @endif

                @if($Shift_Report != null)
                    <td>{{ $Shift_Report->Last24Output }}</td>
                @else
                    <td></td>
                @endif
            </tr>
        </table>
    </div>
    <div class="container-fluid">
        <div class="row mt-2 mb-3">
            <div class="col-1 mx-4"></div>
            <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    @if($Shift_Report != null)
                        <h4 id="TotalFile">{{ $Shift_Report->ProDone }}</h4>
                    @else
                        <h4 id="TotalFile">---</h4>
                    @endif
                    <h4>Total File</h4>
                </center>
                <br>
            </div>
            <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    @if($Shift_Report != null)
                        <h4 id="TotalFile">{{ $Shift_Report->AchieveLoad }}</h4>
                    @else
                        <h4 id="TotalFile">---</h4>
                    @endif
                    <h4>Total Est Time</h4>
                </center>
                <br>
            </div>
            <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    @if($Shift_Report != null)
                        <h4 id="TotalFile">{{ $Shift_Report->AchieveProTime }}</h4>
                    @else
                        <h4 id="TotalFile">---</h4>
                    @endif
                    <h4>Total Pro Time</h4>
                </center>
                <br>
            </div>
            <div class="col-2 shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    @if($Shift_Report != null)
                        <h4 id="TotalFile">{{ $Shift_Report->Efficiency }}%</h4>
                    @else
                        <h4 id="TotalFile">---</h4>
                    @endif
                    <h4>Efficiency</h4>
                </center>
                <br>
            </div>
        </div>

        <?php $isBlank = true; ?>

        @if($Basic->count() != 0)
            <h3 align="center"> Basic Team Workload</h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Service</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Job Time</th>
                    <th>Pro Time</th>
                    <th>Done File</th>
                    <th>Total Job Time</th>
                    <th>Total Pro Time</th>
                </thead>
                <?php
                    $SL = 1;
                    $TotalOutput = 0;
                    $TotalJobTime = 0;
                    $TotalProTime = 0;
                ?>
                @foreach($Basic as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</a></td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>
                        <td>{{$row->Service}}</td>

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

                        <td>{{ $row->Target_Time }}</td>
                        <td>{{ $row->Pro_Time }}</td>
                        <td>{{ $row->Output_File }}</td>
                        <td>{{ Round($row->Output_File * $row->Target_Time) }}</td>
                        <td>{{ Round($row->Output_File * $row->Pro_Time) }}</td>

                        <?php
                            $TotalOutput += $row->Output_File;
                            $TotalJobTime += ($row->Output_File * $row->Target_Time);
                            $TotalProTime += ($row->Output_File * $row->Pro_Time);
                        ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="9" align="right"> <b> Total ---> </b> </td>
                    <td><b> {{ $TotalOutput }} </b></td>
                    <td><b> {{ Round($TotalJobTime) }} </b></td>
                    <td><b> {{ Round($TotalProTime) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if($Advance->count() != 0)
            <h3 align="center"> Advance Team Workload </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Service</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Job Time</th>
                    <th>Pro Time</th>
                    <th>Done File</th>
                    <th>Total Job Time</th>
                    <th>Total Pro Time</th>
                </thead>
                <?php
                    $SL = 1;
                    $TotalOutput = 0;
                    $TotalJobTime = 0;
                    $TotalProTime = 0;
                ?>
                @foreach($Advance as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</a></td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>
                        <td>{{$row->Service}}</td>

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

                        <td>{{$row->Target_Time}}</td>
                        <td>{{$row->Pro_Time}}</td>
                        <td>{{ $row->Output_File }}</td>
                        <td>{{ Round($row->Output_File * $row->Target_Time) }}</td>
                        <td>{{ Round($row->Output_File * $row->Pro_Time) }}</td>

                        <?php
                            $TotalOutput += $row->Output_File;
                            $TotalJobTime += ($row->Output_File * $row->Target_Time);
                            $TotalProTime += ($row->Output_File * $row->Pro_Time);
                        ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="9" align="right"> <b> Total ---> </b> </td>
                    <td><b> {{ $TotalOutput }} </b></td>
                    <td><b> {{ Round($TotalJobTime) }} </b></td>
                    <td><b> {{ Round($TotalProTime) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if($QC_Team->count() != 0)
            <h3 align="center"> QC Team Workload </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Service</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Job Time</th>
                    <th>Pro Time</th>
                    <th>Done File</th>
                    <th>Total Job Time</th>
                    <th>Total Pro Time</th>
                </thead>
                <?php
                    $SL = 1;
                    $TotalOutput = 0;
                    $TotalJobTime = 0;
                    $TotalProTime = 0;
                ?>
                @foreach($QC_Team as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</a></td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>
                        <td>{{$row->Service}}</td>

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

                        <td>{{$row->Target_Time}}</td>
                        <td>{{$row->Pro_Time}}</td>
                        <td>{{ $row->Output_File }}</td>
                        <td>{{ Round($row->Output_File * $row->Target_Time) }}</td>
                        <td>{{ Round($row->Output_File * $row->Pro_Time) }}</td>

                        <?php
                            $TotalOutput += $row->Output_File;
                            $TotalJobTime += ($row->Output_File * $row->Target_Time);
                            $TotalProTime += ($row->Output_File * $row->Pro_Time);
                        ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="9" align="right"> <b> Total ---> </b> </td>
                    <td><b> {{ $TotalOutput }} </b></td>
                    <td><b> {{ Round($TotalJobTime) }} </b></td>
                    <td><b> {{ Round($TotalProTime) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        <br><br><br><br><br>

        @if($isBlank)
            <h3 align="center">There have no reports on selected date & shift.</h3>
        @endif

        <br><br><br><br><br>
    </div>
@endsection
