@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Performance Summary</h3>
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

        <div class="row align-items-center">
            <div class="col mb-2">
                <ul class="nav nav-pills">
                    <li class="nav-item pr-1"><a href="/3/production_tests" class="nav-link btn btn-outline-info"><b>All Test</b></a></li>
                </ul>
            </div>

            <div class="col mb-2">
                <ul class="nav nav-pills justify-content-end">
                    <li class="nav-item pr-1"><a href="/3/production_test_print?id={{$row->id}}" target="_blank" class="nav-link btn btn-outline-info"><b>Print</b></a></li>
                </ul>
            </div>
        </div>

        <div class="mx-5 ml-5 mt-5 h6">            
            <div class="text-center">
                <h2 class="mr-5 mt-4 ml-5">Performance Evaluation Form</h2>
            </div>

            <div class="row mr-0 ml-3 mb-3 mt-3">
                <div class="col-3 pr-0 mr-0">
                    <ul class="nav nav-pills float-right">                        
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <table class="table table-bordered table-striped h5">
                        <tr>
                            <td style="width: 50%;">Employee : <span class="text-primary">{{ $row->full_name }}</span></td>
                            <td>Department : <span class="text-primary">{{ $row->department }}</span></td>
                        </tr>
                        <tr>
                            <td>Designation : <span class="text-primary">{{ $row->designation }}</span></td>
                            <td>Attendence : <span class="text-primary">{{ $row->attendence + 0 }}%</span></td>
                        </tr>
                        <tr>
                            <td>Date of Joining : <span class="text-primary">{{ date('d-M-Y', strtotime($row->joining_date)) }}</span></td>
                            <td>Performance : <span class="text-primary">{{ $row->performance + 0 }}%</span></td>
                        </tr>
                        <tr>
                            <td>Date of Review : <span class="text-primary"> {{ date('d-M-Y', strtotime($row->created_at)) }}</span></td>
                            <td>Efficiency : <span class="text-primary">{{ $row->efficiency + 0 }}%</span></td>
                        </tr>
                        <tr>
                            <td>Current Salary Tk : <span class="text-primary">{{ $row->salary }}</span></td>
                            <td>Increment Tk : <span class="text-primary">{{ $row->salary+$row->increment_ho }}</span></td>
                        </tr>
                        <!-- <tr class="text-center">
                            <td colspan="2">Increment with salary for the month of July 2022..................................</td>
                        </tr> -->
                    </table>
                </div>
            </div>

            <div class="mt-5 mb-3">
                <h4 class="text-center">Shift Incharge Feedback</h4>
            </div>

            <div class="row">
                <div class="col">
                    <table class="table table-bordered table-striped text-center h5">
                        <thead class="text-center">
                            <th style="vertical-align:middle;">Evaluation</th>
                            <th style="vertical-align:middle; width:33%">Sumon</th>
                            <th style="vertical-align:middle; width:33%">Mottaleb</th>
                        </thead>
                        <tr>
                            <td>Test Work Quality : </td>
                            <td><span class="text-primary h5">{{ $row->quality_sumon }}</span></td>
                            <td><span class="text-primary h5">{{ $row->quality_mottaleb }}</span></td>
                        </tr>
                        <tr>
                            <td>Interest to Learn :</td>
                            <td><span class="text-primary h5">{{ $row->interest_sumon }}</span></td>
                            <td><span class="text-primary h5">{{ $row->interest_mottaleb }}</span></td>
                        </tr>
                        <tr>
                            <td>Discipline :</td>
                            <td><span class="text-primary h5">{{ $row->discipline_sumon }}</span></td>
                            <td><span class="text-primary h5">{{ $row->discipline_mottaleb }}</span></td>
                        </tr>
                        <tr>
                            <td>Dedication :</td>
                            <td><span class="text-primary h5">{{ $row->dedication_sumon }}</span></td>
                            <td><span class="text-primary h5">{{ $row->dedication_mottaleb }}</span></td>
                        </tr>
                    </table>
                    <h5 class="text-center text-warning">NB: A = Excellent (5), B = Very Good (4), C = Good (3), D = Average (2), E = Below Average (1)</h5>
                </div>
            </div>

            <div class="mt-5 mb-3">
                <h4 class="text-center">Increment Proposal</h4>
            </div>

            <div class="row">
                <div class="col">        
                    <table class="table table-bordered table-striped text-center">
                        <tr>
                            <td style="width:50% ;">Proposed by PM-Studio :</td>
                            <td class="h5"><span class="text-primary h5">Tk. {{ $row->increment_spm }}</span></td>
                        </tr>
                        <tr>
                            <td>Advice & Comments :</td>
                            <td> {{ $row->remarks_spm }}</td>
                        </tr>
                    </table>
                </div>
                <div class="col">        
                    <table class="table table-bordered table-striped text-center">
                        <tr>
                            <td style="width:50% ;">Proposed by PM-QC_Team :</td>
                            <td class="h5"><span class="text-primary h5">Tk. {{ $row->increment_qpm }}</span></td>
                        </tr>
                        <tr>
                            <td>Advice & Comments :</td>
                            <td> {{ $row->remarks_qpm }}</td>
                        </tr>
                    </table>
                </div>
            </div>            

            <div class="row">
                <div class="col">        
                    <table class="table table-bordered table-striped text-center">
                        <tr>
                            <td style="width:50% ;">Proposed by HR :</td>
                            <td class="h5"><span class="text-primary h5">Tk. {{ $row->increment_hr }}</span></td>
                        </tr>
                        <tr>
                            <td>Advice & Comments :</td>
                            <td> {{ $row->remarks_hr }}</td>
                        </tr>
                    </table>
                </div>
                <div class="col">
                    <table class="table table-bordered table-striped text-center">
                        <tr>
                            <td style="width:50% ;">Approved by MD : </td>
                            <td class="h5"><span class="text-primary h5">Tk. {{ $row->increment_ho }}</span></td>
                        </tr>
                        <tr>
                            <td>Advice & Comments :</td>
                            <td> {{ $row->remarks_ho }}</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>        
        <br><br><br><br><br>
    </div>    
@endsection