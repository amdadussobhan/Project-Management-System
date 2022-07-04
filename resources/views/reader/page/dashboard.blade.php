@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Shift Report </h3>
@endsection

@section('content')
    <div class="container">
        <div class="row align-items-center">
            <div class="col mb-2 px-0 mx-0">
                @include('reader.menu.left_menu')
            </div>

            <div class="col mb-2 px-0 mx-0">
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

        <div class="row mt-2 mb-3">
            <div class="col-1"></div>
            <div class="col-3 bg-white shadow-lg rounded-lg">
                <br>
                <center>
                    @if($Shift_Report != null)
                        <h4>{{ round($Shift_Report->AchieveLoad) }}</h4>
                    @else
                        <h4>---</h4>
                    @endif
                    <h4>Total Est Time</h4>
                </center>
                <br>
            </div>
            <div class="col-3 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    @if($Shift_Report != null)
                        <h4>{{ round($Shift_Report->AchieveProTime) }}</h4>
                    @else
                        <h4>---</h4>
                    @endif
                    <h4>Total Pro Time</h4>
                </center>
                <br>
            </div>
            <div class="col-3 shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    @if($Shift_Report != null)
                        <h4>{{ $Shift_Report->Efficiency }}%</h4>
                    @else
                        <h4>---</h4>
                    @endif
                    <h4>Efficiency</h4>
                </center>
                <br>
            </div>
        </div>

        <div class="row">
            <div class="col-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <thead>
                        <th colspan="2">Selected day's Shift Report</th>
                    </thead>

                    <tr>
                        <td>Total Workload</td>

                        @if($Shift_Report != null)
                            <td>{{ $Shift_Report->TotalLoad }}</td>
                        @else
                            <td>---</td>
                        @endif
                    </tr>

                    <tr>
                        <td>Total Capacity</td>

                        @if($Shift_Report != null)
                            <td>{{ $Shift_Report->Capacity }}</td>
                        @else
                            <td>---</td>
                        @endif
                    </tr>

                    <tr>
                        <td>Pro Done</td>

                        @if($Shift_Report != null)
                            <td>{{ $Shift_Report->ProDone }}</td>
                        @else
                            <td>---</td>
                        @endif
                    </tr>

                    <tr>
                        <td>QC Done</td>

                        @if($Shift_Report != null)
                            <td>{{ $Shift_Report->QcDone }}</td>
                        @else
                            <td>---</td>
                        @endif
                    </tr>

                    <tr>
                        <td>Current Input</td>

                        @if($Shift_Report != null)
                            <td>{{ $Shift_Report->Last24Input }}</td>
                        @else
                            <td>---</td>
                        @endif
                    </tr>

                    <tr>
                        <td>Current Output</td>

                        @if($Shift_Report != null)
                            <td>{{ $Shift_Report->Last24Output }}</td>
                        @else
                            <td>---</td>
                        @endif
                    </tr>
                </table>
            </div>

            <div class="col-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <thead>
                        <th>Date</th>
                        <th>Day</th>
                        <th>Last 24 Input</th>
                        <th>Last 24 Output</th>
                    </thead>
                    @foreach($Weekly_Report as $row)
                        <tr>
                            @if($row != null)
                                <td>{{ date('d-M-Y', strtotime($row->Date)) }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ date('l', strtotime($row->Date)) }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ $row->Last24Input }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ $row->Last24Output }}</td>
                            @else
                                <td></td>
                            @endif
                        </tr>
                    @endforeach
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <thead>
                        <th colspan="4">Selected day's Pro_done</th>
                    </thead>
                    <tr>
                        <td>Team/Shift</td>
                        <td>Morning Shift</td>
                        <td>Evening Shift</td>
                        <td>Night Shift</td>
                    </tr>
                    <tr>
                        <td>Basic Team</td>

                        @if($Current_Morning_Basic != null)
                            <td>{{ $Current_Morning_Basic->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Current_Evening_Basic != null)
                            <td>{{ $Current_Evening_Basic->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Current_Night_Basic != null)
                            <td>{{ $Current_Night_Basic->ProDone }}</td>
                        @else
                            <td></td>
                        @endif
                    </tr>
                    <tr>
                        <td>Advance Team</td>

                        @if($Current_Morning_Advance != null)
                            <td>{{ $Current_Morning_Advance->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Current_Evening_Advance != null)
                            <td>{{ $Current_Evening_Advance->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Current_Night_Advance != null)
                            <td>{{ $Current_Night_Advance->ProDone }}</td>
                        @else
                            <td></td>
                        @endif
                    </tr>
                    <tr>
                        <td>QC Team</td>

                        @if($Current_Morning_QC_Team != null)
                            <td>{{ $Current_Morning_QC_Team->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Current_Evening_QC_Team != null)
                            <td>{{ $Current_Evening_QC_Team->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Current_Night_QC_Team != null)
                            <td>{{ $Current_Night_QC_Team->ProDone }}</td>
                        @else
                            <td></td>
                        @endif
                    </tr>
                </table>
            </div>

            <div class="col-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <thead>
                        <th colspan="4">Previous day's Pro_done</th>
                    </thead>
                    <tr>
                        <td>Team/Shift</td>
                        <td>Morning Shift</td>
                        <td>Evening Shift</td>
                        <td>Night Shift</td>
                    </tr>
                    <tr>
                        <td>Basic Team</td>

                        @if($Last_Morning_Basic != null)
                            <td>{{ $Last_Morning_Basic->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Last_Evening_Basic != null)
                            <td>{{ $Last_Evening_Basic->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Last_Night_Basic != null)
                            <td>{{ $Last_Night_Basic->ProDone }}</td>
                        @else
                            <td></td>
                        @endif
                    </tr>
                    <tr>
                        <td>Advance Team</td>

                        @if($Last_Morning_Advance != null)
                            <td>{{ $Last_Morning_Advance->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Last_Evening_Advance != null)
                            <td>{{ $Last_Evening_Advance->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Last_Night_Advance != null)
                            <td>{{ $Last_Night_Advance->ProDone }}</td>
                        @else
                            <td></td>
                        @endif
                    </tr>
                    <tr>
                        <td>QC Team</td>

                        @if($Last_Morning_QC_Team != null)
                            <td>{{ $Last_Morning_QC_Team->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Last_Evening_QC_Team != null)
                            <td>{{ $Last_Evening_QC_Team->ProDone }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($Last_Night_QC_Team != null)
                            <td>{{ $Last_Night_QC_Team->ProDone }}</td>
                        @else
                            <td></td>
                        @endif
                    </tr>
                </table>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <table class="table table-bordered table-striped text-center table-sm">
                    <thead>
                        <th colspan="5" class="bg-success">Best Performer in selected shift</th>
                    </thead>
                    <tr>
                        <th>Name</th>
                        <th>Total File</th>
                        <th>Job Time</th>
                        <th>Pro Time</th>
                        <th>Efficiency</th>
                    </tr>

                    @foreach($best_performer as $row)
                        <tr>
                            @if($row != null)
                                <td>{{ $row->Name }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ $row->File }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ round($row->JobTime) }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ round($row->ProTime) }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ $row->Efficiency }}%</td>
                            @else
                                <td></td>
                            @endif
                        </tr>
                    @endforeach
                </table>
            </div>

            <div class="col">
                <table class="table table-bordered table-striped text-center table-sm">
                    <thead>
                        <th colspan="5" class="bg-warning">Below Performer in selected shift</th>
                    </thead>
                    <tr>
                        <th>Name</th>
                        <th>Total File</th>
                        <th>Job Time</th>
                        <th>Pro Time</th>
                        <th>Efficiency</th>
                    </tr>

                    @foreach($bad_performer as $row)
                        <tr>
                            @if($row != null)
                                <td>{{ $row->Name }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ $row->File }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ round($row->JobTime) }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ round($row->ProTime) }}</td>
                            @else
                                <td></td>
                            @endif

                            @if($row != null)
                                <td>{{ $row->Efficiency }}%</td>
                            @else
                                <td></td>
                            @endif
                        </tr>
                    @endforeach
                </table>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <br><br><br><br><br>
    </div>
@endsection

<script>    
    //Job Page Script
    var TotalFileValue = document.getElementById("TotalFileValue").value;
    var TotalEstTimeValue = document.getElementById("TotalEstTimeValue").value;
    var TotalProTimeValue = document.getElementById("TotalProTimeValue").value;
    var EfficiencyValue = document.getElementById("EfficiencyValue").value;
    //var AverageTimeValue = document.getElementById("AverageTimeValue").value;

    $('#TotalFile').text(TotalFileValue);
    $('#TotalEstTime').text(TotalEstTimeValue);
    $('#TotalProTime').text(TotalProTimeValue);
    $('#Efficiency').text(EfficiencyValue+'%');
    //$('#ProTime').text(AverageTimeValue);
</script>