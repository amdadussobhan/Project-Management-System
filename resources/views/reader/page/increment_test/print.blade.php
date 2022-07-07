<?php
    use Illuminate\Support\Facades\Auth;
    $role = Auth::User()->role; 
?>

<!doctype html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>{{ config('app.name', 'Laravel') }}</title>
        <script src="{{ asset('js/app.js') }}" defer></script>
        <link href="{{ asset('css/app.css') }}" rel="stylesheet">
        <link href="{{ asset('css/bootstrap.min.css') }}" rel="stylesheet">
        <link href="{{ asset('css/all.min.css') }}" rel="stylesheet">
        <link href="{{ asset('css/style.css') }}" rel="stylesheet">
    </head>
    <body>
        <div class="container mt-5 pt-5">
        <div class="h6">            
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
                            <td>Current Salary : <span class="text-primary">{{ $row->salary }}</span></td>
                            <td>Increment Salary : <span class="text-primary">{{ $row->increment_ho }}</span></td>
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
                        <tr class="text-center">
                            <td style="vertical-align:middle;">Evaluation</td>
                            <td style="vertical-align:middle; width:33%">Sumon</td>
                            <td style="vertical-align:middle; width:33%;">Mottaleb</td>
                        </tr>
                        <tr>
                            <td class="">Test Work Quality : </td>
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

            <div class="row ml-5 mt-5 pt-5">
                <div class="col text-center mt-5">
                    <h5>Zubaer Ibne Shahid</h5>
                    <h6>Sr.Manager-HR & Production Admin</h6>
                </div>
                <div class="col text-center mt-5">
                    <h5>Nasrul Azam Azad</h5>
                    <h6>Head of Business</h6>
                </div>
                <div class="col text-center mt-5">
                    <h5>Tahsin Saeed</h5>
                    <h6>Managing Director</h6>
                </div>
            </div>
        </div>        
        <br><br><br><br><br>
        </div>

        <!-- Scripts-->
        <script src="{{ asset('js/jQuery_3.5.1.js') }}" defer></script>
        <script src="{{ asset('js/bootstrap.min.js') }}" defer></script>
        <script src="{{ asset('js/all.min.js') }}" defer></script>
        <script src="{{ asset('js/function.js') }}" defer></script>
        <script src="{{ asset('js/app.js') }}" defer></script>
        <script>
            window.onload = function () {
                window.print();
            }
        </script>
    </body>
</html>
