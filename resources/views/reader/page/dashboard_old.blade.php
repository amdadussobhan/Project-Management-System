@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Dashboard </h3>
@endsection

@section('content')
    <div class="container-fluid">
        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                    @include('reader.menu.filter_dashboard')
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

        <br>
        <div class="container-fluid pl-5 ml-4">
            <div class="row">
                <div class="col-1 mx-5"></div>

                @if($row != null)
                    @if($row->Capacity == 0)
                        <div class="col-3 bg-white shadow-lg rounded-lg ml-5 mr-1">
                    @elseif($row->Capacity >= $row->TotalLoad)
                        <div class="col-3 bg-success shadow-lg rounded-lg ml-5 mr-1">
                    @else
                        <div class="col-3 bg-danger shadow-lg rounded-lg ml-5 mr-1">
                    @endif
                @else
                    <div class="col-3 bg-white shadow-lg rounded-lg ml-5 mr-1">
                @endif
                    <br>
                    <center>
                        <a href="/3/attendence?date={{$date}}&shift={{$shift}}" class="text-dark">
                            @if($row != null)
                                <h3>{{$row->Capacity}}</h3>
                            @else
                                <h3>---</h3>
                            @endif
                            <h3>Capacity</h3>
                        </a>
                    </center>
                    <br>
                </div>

                <div class="col-1 mx-5"></div>

                @if($row != null)
                    @if($row->TotalLoad == 0)
                        <div class="col-3 bg-white shadow-lg rounded-lg">
                    @elseif($row->TotalLoad >= $row->Capacity)
                        <div class="col-3 bg-success shadow-lg rounded-lg">
                    @else
                        <div class="col-3 bg-warning shadow-lg rounded-lg">
                    @endif
                @else
                    <div class="col-3 bg-white shadow-lg rounded-lg">
                @endif
                    <br>
                    <center>
                        <a href="/3/workloads?date={{$date}}&shift={{$shift}}" class="text-dark">
                            @if($row != null)
                                <h3>{{$row->TotalLoad}}</h3>
                            @else
                                <h3>---</h3>
                            @endif
                            <h3>Workload</h3>
                        </a>
                    </center>
                    <br>
                </div>
            </div>

            <br>
            <div class="row">
                <div class="col-1"></div>

                @if($row != null)
                    @if($row->CapacityAchieve == 0)
                        <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    @elseif($row->CapacityAchieve >= 100)
                        <div class="col-2 bg-success shadow-lg rounded-lg ml-5">
                    @else
                        <div class="col-2 bg-warning shadow-lg rounded-lg ml-5">
                @endif
                @else
                    <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                @endif
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->CapacityAchieve}}%</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Capacity Achieve</h4>
                    </center>
                    <br>
                </div>

                @if($row != null)
                    @if($row->Efficiency >= 100)
                        <div class="col-2 bg-success shadow-lg rounded-lg ml-5">
                    @elseif($row->Efficiency >= 90)
                        <div class="col-2 bg-warning shadow-lg rounded-lg ml-5">
                    @else
                        <div class="col-2 bg-danger shadow-lg rounded-lg ml-5">
                    @endif
                @else
                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    @endif
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{ Round($row->AchieveProTime) }}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Done(Pro Time)</h4>
                    </center>
                    <br>
                </div>

                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{ Round($row->AchieveLoad) }}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Done(Target Time)</h4>
                    </center>
                    <br>
                </div>


                @if($row != null)
                    @if($row->TargetAchieve == 0)
                        <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    @elseif($row->TargetAchieve >= 100)
                        <div class="col-2 bg-success shadow-lg rounded-lg ml-5">
                    @else
                        <div class="col-2 bg-warning shadow-lg rounded-lg ml-5">
                    @endif
                @else
                    <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                @endif
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->TargetAchieve}}%</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Workload Achieve</h4>
                    </center>
                    <br>
                </div>
            </div>

            <br>
            <div class="row">

                <div class="col-2 ml-5"></div>
                @if($row != null)
                    @if($row->Quality >= 100)
                        <div class="col-2 bg-success shadow-lg rounded-lg ml-5">
                    @elseif($row->Quality >= 90)
                        <div class="col-2 bg-warning shadow-lg rounded-lg ml-5">
                    @else
                        <div class="col-2 bg-danger shadow-lg rounded-lg ml-5">
                    @endif
                @else
                    <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                @endif
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->Quality}}%</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Quality</h4>
                    </center>
                    <br>
                </div>

                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        <h4>---</h4>
                        <h4>Revenue</h4>
                    </center>
                    <br>
                </div>

                @if($row != null)
                    @if($row->Efficiency >= 100)
                        <div class="col-2 bg-success shadow-lg rounded-lg ml-5">
                    @elseif($row->Efficiency >= 90)
                        <div class="col-2 bg-warning shadow-lg rounded-lg ml-5">
                    @else
                        <div class="col-2 bg-danger shadow-lg rounded-lg ml-5">
                    @endif
                @else
                    <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                @endif
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->Efficiency}}%</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Efficiency</h4>
                    </center>
                    <br>
                </div>
            </div>

            <br>
            <div class="row">
                <div class="col-2 bg-white shadow-lg rounded-lg ml-4">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->PreFile}}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Previous files</h4>
                    </center>
                    <br>
                </div>

                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->NewFile}}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>New files receive</h4>
                    </center>
                    <br>
                </div>

                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->TotalFile}}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Total files</h4>
                    </center>
                    <br>
                </div>

                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->ProDone}}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Pro Done files</h4>
                    </center>
                    <br>
                </div>

                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->QcDone}}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>QC Done files</h4>
                    </center>
                    <br>
                </div>
            </div>

            <br>
            <div class="row">
                <div class="col-3 mr-5"></div>
                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->Last24Input}}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Last 24H Input files</h4>
                    </center>
                    <br>
                </div>

                <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                    <br>
                    <center>
                        @if($row != null)
                            <h4>{{$row->Last24Output}}</h4>
                        @else
                            <h4>---</h4>
                        @endif
                        <h4>Last 24H Output files</h4>
                    </center>
                    <br>
                </div>
            </div>
        </div>
    </div>
@endsection
