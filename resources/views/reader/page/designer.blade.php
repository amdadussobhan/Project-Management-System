@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Job Details</h3>
@endsection

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
        <hr>
        <div class="row">
            <div class="col-md-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <tr>
                        <td><h5 class="d-inline"><strong>Name : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->Name}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Shift : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->Shift}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>File Amount : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->File}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Quality : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->Quality}}%
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Efficiency : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->Efficiency}}%
                                @endif
                            </h6>
                        </td>
                    </tr>

                </table>

            </div>

            <div class="col-md-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <tr>
                        <td><h5 class="d-inline"><strong>Login Time : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->Login}}
                                @endif
                            </h6>
                        </td>
                    </tr>
                    <tr>
                        <td><h5 class="d-inline"><strong>Logout Time : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->Logout}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Working Time : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{$designer->WorkingTime}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Est Time : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($designer != null)
                                    {{round($designer->JobTime)}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Pro Time : </strong></h5></td>
                        <td>
                            <h6 class="d-inline" id="ProTime">
                                @if($designer != null)
                                    {{round($designer->ProTime)}}
                                @endif
                            </h6>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="container-fluid">

        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                    @include('reader.menu.filter_designer')
                </div>
            </div>
        </strong>

        <div class="row mt-2 mb-3">
            <div class="col-1 mx-4"></div>
            <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    <h4 id="TotalFile">---</h4>
                    <h4>Total File</h4>
                </center>
                <br>
            </div>
            <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    <h4 id="TotalEstTime">---</h4>
                    <h4>Total Est Time</h4>
                </center>
                <br>
            </div>
            <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    <h4 id="TotalProTime">---</h4>
                    <h4>Total Pro Time</h4>
                </center>
                <br>
            </div>
            <div class="col-2 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    <h4 id="Efficiency">---</h4>
                    <h4>Efficiency</h4>
                </center>
                <br>
            </div>
        </div>

        <table class="table table-hover table-bordered table-striped text-center table-sm">
            <thead>
            <th style="vertical-align:middle;">SL</th>
            <th style="vertical-align:middle;">Job ID</th>
            <th style="vertical-align:middle;">Category</th>
            <th style="vertical-align:middle;">Service</th>
            <th style="width: 20%; vertical-align:middle;">Image</th>
            <th style="vertical-align:middle;">Start Time</th>
            <th style="vertical-align:middle;">End Time</th>
            <th style="vertical-align:middle;">Target Time</th>
            <th style="vertical-align:middle;">Pro File</th>
            <th style="vertical-align:middle;">Quality</th>
            <th style="vertical-align:middle;">Efficiency</th>
            </thead>
            <?php
                $SL = 0;
                $TotalEstTime = 0;
                $TotalProTime = 0;
                $Efficiency = 0;
                $AverageTime = 0;
            ?>
            @foreach($rows as $row)
                @if($row->Efficiency != null)
                    @if($row->Efficiency > 400)
                        <tr>
                    @elseif($row->Efficiency >= 100)
                        <tr style="background: #8cd985">
                    @elseif($row->Efficiency >= 90)
                        <tr style="background: #fff8b3">
                    @else
                        <tr style="background: #f1b0b7">
                    @endif
                @else
                    <tr>
                @endif
                    <td>{{++$SL}}</td>
                    <td><a href="/3/job?job_id={{$row->JobId}}&date={{ $date }}" target="_blank">{{$row->JobId}}</a></td>
                    <td>{{$row->Type}}</td>
                    <td>{{$row->Service}}</td>
                    <td>{{$row->Image}}</td>
                    <td>{{ date('d-M-Y h:i:s A', strtotime($row->StartTime)) }}</td>
                    <td>{{ date('d-M-Y h:i:s A', strtotime($row->EndTime)) }}</td>
                    <td>{{$row->TargetTime}}</td>
                    <td>{{$row->ProTime}}</td>
                    <td>{{$row->Quality}}%</td>
                    <td>{{$row->Efficiency}}%</td>
                    </tr>

                    <?php
                        if($row->Efficiency <= 400){
                            $TotalEstTime += $row->TargetTime;
                            $TotalProTime += $row->ProTime;
                        }
                    ?>
            @endforeach
        </table>

        <?php
            if ($TotalProTime != 0)
                $Efficiency = round($TotalEstTime / $TotalProTime * 100, 0);

            if ($SL != 0)
                $AverageTime = $TotalProTime / $SL;

            $TotalEstTime = round($TotalEstTime);
            $TotalProTime = round($TotalProTime);
        ?>

        <input type="hidden" id="TotalFileValue" value="{{ $SL }}">
        <input type="hidden" id="TotalEstTimeValue" value="{{ $TotalEstTime }}">
        <input type="hidden" id="TotalProTimeValue" value="{{ $TotalProTime }}">
        <input type="hidden" id="EfficiencyValue" value="{{ $Efficiency }}">
        <input type="hidden" id="AverageTimeValue" value="{{ $AverageTime }}">

        <br><br><br><br><br><br><br><br>
    </div>
@endsection
