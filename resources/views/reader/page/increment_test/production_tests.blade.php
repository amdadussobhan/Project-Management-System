<?php
    use Illuminate\Support\Facades\Auth;
    $user = Auth::user()->id;
?>

@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Jobs List </h3>
@endsection

@section('content')
    <div class="container-fluid">
        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                    @include('reader.menu.filter_production_test')
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

        <table class="table table-bordered table-striped text-center table-sm">
            <thead>
                <th style="vertical-align:middle;">SL</th>
                <th style="vertical-align:middle;">Name</th>
                <th style="vertical-align:middle;">Full Name</th>
                <th style="vertical-align:middle;">Employee ID</th>
                <th style="vertical-align:middle;">Designation</th>
                
                @if($user != 5 & $user != 10)
                    <th style="vertical-align:middle;">Team</th>
                @endif

                <th style="vertical-align:middle;">Attendence</th>
                <th style="vertical-align:middle;">Performance</th>
                <th style="vertical-align:middle;">Efficiency</th>
                
                @if($user == 8 | $user == 11 | $user == 12 | $user == 130)
                    <th style="vertical-align:middle;">Quality</th>
                    <th style="vertical-align:middle;">Interest</th>
                    <th style="vertical-align:middle;">Discipline</th>
                    <th style="vertical-align:middle;">Dedication</th>
                @endif

                <th style="vertical-align:middle;">Overall</th>

                @if($user == 8 | $user == 130)
                    <th style="vertical-align:middle;">My-Suggest</th>
                @endif

                @if($user == 5 | $user == 10)
                    <th style="vertical-align:middle;">PM-QC_Team</th>
                    <th style="vertical-align:middle;">PM-Studio</th>
                    <th style="vertical-align:middle;">HR Manager</th>
                    <th style="vertical-align:middle;">MD/HO</th>
                @endif

                <th style="vertical-align:middle;">Action</th>
            </thead>
            
            <?php $SL = 1; ?>
            @if($advances != null)
                <tr><td colspan="14" class="py-0"><h4>Advance Test</h3></td></tr>
                @foreach($advances as $advance)
                    <tr>
                        <td>{{ $SL++ }}</td>
                        
                        @if($user == 5 | $user == 10)
                            <td><a href="/3/production_test?id={{$advance->id}}" target="_blank">{{$advance->name}}</a></td>
                        @else
                            <td><a href="/3/test_report?name={{$advance->name}}" target="_blank">{{$advance->name}}</a></td>
                        @endif

                        <td>{{ $advance->full_name }}</td>
                        <td>{{ $advance->employee_id }}</td>
                        <td>{{ $advance->designation }}</td>
                        
                        @if($user != 5 & $user != 10)
                            <td>{{ $advance->team }}</td>
                        @endif

                        @if($advance->attendence >= 100)
                            <td style="background: #8cd985">{{ $advance->attendence + 0 }}%</td>
                        @elseif($advance->attendence >= 90)
                            <td style="background: #fff8b3">{{ $advance->attendence + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $advance->attendence + 0 }}%</td>
                        @endif

                        @if($advance->performance >= 100)
                            <td style="background: #8cd985">{{ $advance->performance + 0 }}%</td>
                        @elseif($advance->performance >= 90)
                            <td style="background: #fff8b3">{{ $advance->performance + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $advance->performance + 0 }}%</td>
                        @endif

                        @if($advance->efficiency >= 100)
                            <td style="background: #8cd985">{{ $advance->efficiency + 0 }}%</td>
                        @elseif($advance->efficiency >= 90)
                            <td style="background: #fff8b3">{{ $advance->efficiency + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $advance->efficiency + 0 }}%</td>
                        @endif

                        @if($user == 11)
                            <td>{{ $advance->quality_sumon }}</td>
                            <td>{{ $advance->interest_sumon }}</td>
                            <td>{{ $advance->discipline_sumon }}</td>
                            <td>{{ $advance->dedication_sumon }}</td>
                        @endif

                        @if($user == 12)
                            <td>{{ $advance->quality_mottaleb }}</td>
                            <td>{{ $advance->interest_mottaleb }}</td>
                            <td>{{ $advance->discipline_mottaleb }}</td>
                            <td>{{ $advance->dedication_mottaleb }}</td>
                        @endif

                        @if($user == 8 | $user == 130)
                            <td>{{ $advance->quality_overall }}</td>
                            <td>{{ $advance->interest_overall }}</td>
                            <td>{{ $advance->discipline_overall }}</td>
                            <td>{{ $advance->dedication_overall }}</td>
                        @endif

                        @if($advance->overall == "A")
                            <td style="background: #8cd985">{{ $advance->overall }}</td>
                        @elseif($advance->overall == "B" | $advance->overall == "C")
                            <td style="background: #fff8b3">{{ $advance->overall }}</td>
                        @else
                            <td style="background: #f1b0b7">{{ $advance->overall }}</td>
                        @endif

                        @if($user == 130)
                            <td>{{$advance->increment_spm}}</td>
                        @endif

                        @if($user == 8)
                            <td>{{$advance->increment_qpm}}</td>
                        @endif

                        @if($user == 5 | $user == 10)
                            <td>{{ $advance->increment_qpm }}</td>
                            <td>{{ $advance->increment_spm }}</td>
                            <td>{{ $advance->increment_hr }}</td>
                            <td>{{ $advance->increment_ho }}</td>
                        @endif

                        @if($user == 1)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="edit_efficiency" data-toggle="modal" data-target="#edit_efficiency" 
                                    data-production_test_id="{{$advance->id}}" data-performance="{{$advance->performance}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 5)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$advance->id}}" data-name="{{$advance->name}}" data-amount="{{$advance->increment_ho}}" 
                                    data-remarks="{{$advance->remarks_ho}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 130)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$advance->id}}" data-name="{{$advance->name}}" data-amount="{{$advance->increment_spm}}" 
                                    data-remarks="{{$advance->remarks_spm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 8)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$advance->id}}" data-name="{{$advance->name}}" data-amount="{{$advance->increment_qpm}}" 
                                    data-remarks="{{$advance->remarks_qpm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 10)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="hr_feedback" data-toggle="modal" data-target="#hr_feedback"
                                    data-hr_increment_id="{{$advance->id}}" data-name="{{$advance->name}}" data-amount="{{$advance->increment_hr}}" 
                                    data-remarks="{{$advance->remarks_hr}}" data-salary="{{$advance->salary}}" data-attendence="{{$advance->attendence}}" 
                                    data-department="{{$advance->department}}" data-date="{{$advance->joining_date}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 11 | $user == 12)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="si_feedback" data-toggle="modal" data-target="#si_feedback" 
                                    data-si_increment_id="{{$advance->id}}" data-designer_name="{{$advance->name}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif
                    </tr>
                @endforeach
            @endif
            
            <?php $SL = 1; ?>
            @if($seniors != null)
                <tr><td colspan="14" class="py-0"><h4>Senior Test</h3></td></tr>
                @foreach($seniors as $senior)
                    <tr>
                        <td>{{ $SL++ }}</td>
                        
                        @if($user == 5 | $user == 10)
                            <td><a href="/3/production_test?id={{$senior->id}}" target="_blank">{{$senior->name}}</a></td>
                        @else
                            <td><a href="/3/test_report?name={{$senior->name}}" target="_blank">{{$senior->name}}</a></td>
                        @endif

                        <td>{{ $senior->full_name }}</td>
                        <td>{{ $senior->employee_id }}</td>
                        <td>{{ $senior->designation }}</td>
                        
                        @if($user != 5 & $user != 10)
                            <td>{{ $senior->team }}</td>
                        @endif

                        @if($senior->attendence >= 100)
                            <td style="background: #8cd985">{{ $senior->attendence + 0 }}%</td>
                        @elseif($senior->attendence >= 90)
                            <td style="background: #fff8b3">{{ $senior->attendence + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $senior->attendence + 0 }}%</td>
                        @endif

                        @if($senior->performance >= 100)
                            <td style="background: #8cd985">{{ $senior->performance + 0 }}%</td>
                        @elseif($senior->performance >= 90)
                            <td style="background: #fff8b3">{{ $senior->performance + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $senior->performance + 0 }}%</td>
                        @endif

                        @if($senior->efficiency >= 100)
                            <td style="background: #8cd985">{{ $senior->efficiency + 0 }}%</td>
                        @elseif($senior->efficiency >= 90)
                            <td style="background: #fff8b3">{{ $senior->efficiency + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $senior->efficiency + 0 }}%</td>
                        @endif

                        @if($user == 11)
                            <td>{{ $senior->quality_sumon }}</td>
                            <td>{{ $senior->interest_sumon }}</td>
                            <td>{{ $senior->discipline_sumon }}</td>
                            <td>{{ $senior->dedication_sumon }}</td>
                        @endif

                        @if($user == 12)
                            <td>{{ $senior->quality_mottaleb }}</td>
                            <td>{{ $senior->interest_mottaleb }}</td>
                            <td>{{ $senior->discipline_mottaleb }}</td>
                            <td>{{ $senior->dedication_mottaleb }}</td>
                        @endif

                        @if($user == 8 | $user == 130)
                            <td>{{ $senior->quality_overall }}</td>
                            <td>{{ $senior->interest_overall }}</td>
                            <td>{{ $senior->discipline_overall }}</td>
                            <td>{{ $senior->dedication_overall }}</td>
                        @endif

                        @if($senior->overall == "A")
                            <td style="background: #8cd985">{{ $senior->overall }}</td>
                        @elseif($senior->overall == "B" | $senior->overall == "C")
                            <td style="background: #fff8b3">{{ $senior->overall }}</td>
                        @else
                            <td style="background: #f1b0b7">{{ $senior->overall }}</td>
                        @endif

                        @if($user == 130)
                            <td>{{$senior->increment_spm}}</td>
                        @endif

                        @if($user == 8)
                            <td>{{$senior->increment_qpm}}</td>
                        @endif

                        @if($user == 5 | $user == 10)
                            <td>{{ $senior->increment_qpm }}</td>
                            <td>{{ $senior->increment_spm }}</td>
                            <td>{{ $senior->increment_hr }}</td>
                            <td>{{ $senior->increment_ho }}</td>
                        @endif

                        @if($user == 1)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="edit_efficiency" data-toggle="modal" data-target="#edit_efficiency" 
                                    data-production_test_id="{{$senior->id}}" data-performance="{{$senior->performance}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 5)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$senior->id}}" data-name="{{$senior->name}}" data-amount="{{$senior->increment_ho}}" 
                                    data-remarks="{{$senior->remarks_ho}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 130)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$senior->id}}" data-name="{{$senior->name}}" data-amount="{{$senior->increment_spm}}" 
                                    data-remarks="{{$senior->remarks_spm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 8)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$senior->id}}" data-name="{{$senior->name}}" data-amount="{{$senior->increment_qpm}}" 
                                    data-remarks="{{$senior->remarks_qpm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 10)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="hr_feedback" data-toggle="modal" data-target="#hr_feedback"
                                    data-hr_increment_id="{{$senior->id}}" data-name="{{$senior->name}}" data-amount="{{$senior->increment_hr}}" 
                                    data-remarks="{{$senior->remarks_hr}}" data-salary="{{$senior->salary}}" data-attendence="{{$senior->attendence}}" 
                                    data-department="{{$senior->department}}" data-date="{{$senior->joining_date}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 11 | $user == 12)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="si_feedback" data-toggle="modal" data-target="#si_feedback" 
                                    data-si_increment_id="{{$senior->id}}" data-designer_name="{{$senior->name}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif
                    </tr>
                @endforeach
            @endif
            
            <?php $SL = 1; ?>
            @if($basics != null)
                <tr><td colspan="14" class="py-0"><h4>Basic Test</h3></td></tr>
                @foreach($basics as $basic)
                    <tr>
                        <td>{{ $SL++ }}</td>
                        
                        @if($user == 5 | $user == 10)
                            <td><a href="/3/production_test?id={{$basic->id}}" target="_blank">{{$basic->name}}</a></td>
                        @else
                            <td><a href="/3/test_report?name={{$basic->name}}" target="_blank">{{$basic->name}}</a></td>
                        @endif

                        <td>{{ $basic->full_name }}</td>
                        <td>{{ $basic->employee_id }}</td>
                        <td>{{ $basic->designation }}</td>
                        
                        @if($user != 5 & $user != 10)
                            <td>{{ $basic->team }}</td>
                        @endif

                        @if($basic->attendence >= 100)
                            <td style="background: #8cd985">{{ $basic->attendence + 0 }}%</td>
                        @elseif($basic->attendence >= 90)
                            <td style="background: #fff8b3">{{ $basic->attendence + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $basic->attendence + 0 }}%</td>
                        @endif

                        @if($basic->performance >= 100)
                            <td style="background: #8cd985">{{ $basic->performance + 0 }}%</td>
                        @elseif($basic->performance >= 90)
                            <td style="background: #fff8b3">{{ $basic->performance + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $basic->performance + 0 }}%</td>
                        @endif

                        @if($basic->efficiency >= 100)
                            <td style="background: #8cd985">{{ $basic->efficiency + 0 }}%</td>
                        @elseif($basic->efficiency >= 90)
                            <td style="background: #fff8b3">{{ $basic->efficiency + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $basic->efficiency + 0 }}%</td>
                        @endif

                        @if($user == 11)
                            <td>{{ $basic->quality_sumon }}</td>
                            <td>{{ $basic->interest_sumon }}</td>
                            <td>{{ $basic->discipline_sumon }}</td>
                            <td>{{ $basic->dedication_sumon }}</td>
                        @endif

                        @if($user == 12)
                            <td>{{ $basic->quality_mottaleb }}</td>
                            <td>{{ $basic->interest_mottaleb }}</td>
                            <td>{{ $basic->discipline_mottaleb }}</td>
                            <td>{{ $basic->dedication_mottaleb }}</td>
                        @endif

                        @if($user == 8 | $user == 130)
                            <td>{{ $basic->quality_overall }}</td>
                            <td>{{ $basic->interest_overall }}</td>
                            <td>{{ $basic->discipline_overall }}</td>
                            <td>{{ $basic->dedication_overall }}</td>
                        @endif

                        @if($basic->overall == "A")
                            <td style="background: #8cd985">{{ $basic->overall }}</td>
                        @elseif($basic->overall == "B" | $basic->overall == "C")
                            <td style="background: #fff8b3">{{ $basic->overall }}</td>
                        @else
                            <td style="background: #f1b0b7">{{ $basic->overall }}</td>
                        @endif

                        @if($user == 130)
                            <td>{{$basic->increment_spm}}</td>
                        @endif

                        @if($user == 8)
                            <td>{{$basic->increment_qpm}}</td>
                        @endif

                        @if($user == 5 | $user == 10)
                            <td>{{ $basic->increment_qpm }}</td>
                            <td>{{ $basic->increment_spm }}</td>
                            <td>{{ $basic->increment_hr }}</td>
                            <td>{{ $basic->increment_ho }}</td>
                        @endif

                        @if($user == 1)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="edit_efficiency" data-toggle="modal" data-target="#edit_efficiency" 
                                    data-production_test_id="{{$basic->id}}" data-performance="{{$basic->performance}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 5)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$basic->id}}" data-name="{{$basic->name}}" data-amount="{{$basic->increment_ho}}" 
                                    data-remarks="{{$basic->remarks_ho}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 130)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$basic->id}}" data-name="{{$basic->name}}" data-amount="{{$basic->increment_spm}}" 
                                    data-remarks="{{$basic->remarks_spm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 8)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$basic->id}}" data-name="{{$basic->name}}" data-amount="{{$basic->increment_qpm}}" 
                                    data-remarks="{{$basic->remarks_qpm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 10)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="hr_feedback" data-toggle="modal" data-target="#hr_feedback"
                                    data-hr_increment_id="{{$basic->id}}" data-name="{{$basic->name}}" data-amount="{{$basic->increment_hr}}" 
                                    data-remarks="{{$basic->remarks_hr}}" data-salary="{{$basic->salary}}" data-attendence="{{$basic->attendence}}" 
                                    data-department="{{$basic->department}}" data-date="{{$basic->joining_date}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 11 | $user == 12)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="si_feedback" data-toggle="modal" data-target="#si_feedback" 
                                    data-si_increment_id="{{$basic->id}}" data-designer_name="{{$basic->name}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif
                    </tr>
                @endforeach
            @endif
            
            <?php $SL = 1; ?>
            @if($clippers != null)
                <tr><td colspan="14" class="py-0"><h4>Clipper Test</h3></td></tr>
                @foreach($clippers as $clipper)
                    <tr>
                        <td>{{ $SL++ }}</td>
                        
                        @if($user == 5 | $user == 10)
                            <td><a href="/3/production_test?id={{$clipper->id}}" target="_blank">{{$clipper->name}}</a></td>
                        @else
                            <td><a href="/3/test_report?name={{$clipper->name}}" target="_blank">{{$clipper->name}}</a></td>
                        @endif

                        <td>{{ $clipper->full_name }}</td>
                        <td>{{ $clipper->employee_id }}</td>
                        <td>{{ $clipper->designation }}</td>
                        
                        @if($user != 5 & $user != 10)
                            <td>{{ $clipper->team }}</td>
                        @endif

                        @if($clipper->attendence >= 100)
                            <td style="background: #8cd985">{{ $clipper->attendence + 0 }}%</td>
                        @elseif($clipper->attendence >= 90)
                            <td style="background: #fff8b3">{{ $clipper->attendence + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $clipper->attendence + 0 }}%</td>
                        @endif

                        @if($clipper->performance >= 100)
                            <td style="background: #8cd985">{{ $clipper->performance + 0 }}%</td>
                        @elseif($clipper->performance >= 90)
                            <td style="background: #fff8b3">{{ $clipper->performance + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $clipper->performance + 0 }}%</td>
                        @endif

                        @if($clipper->efficiency >= 100)
                            <td style="background: #8cd985">{{ $clipper->efficiency + 0 }}%</td>
                        @elseif($clipper->efficiency >= 90)
                            <td style="background: #fff8b3">{{ $clipper->efficiency + 0 }}%</td>
                        @else
                            <td style="background: #f1b0b7">{{ $clipper->efficiency + 0 }}%</td>
                        @endif

                        @if($user == 11)
                            <td>{{ $clipper->quality_sumon }}</td>
                            <td>{{ $clipper->interest_sumon }}</td>
                            <td>{{ $clipper->discipline_sumon }}</td>
                            <td>{{ $clipper->dedication_sumon }}</td>
                        @endif

                        @if($user == 12)
                            <td>{{ $clipper->quality_mottaleb }}</td>
                            <td>{{ $clipper->interest_mottaleb }}</td>
                            <td>{{ $clipper->discipline_mottaleb }}</td>
                            <td>{{ $clipper->dedication_mottaleb }}</td>
                        @endif

                        @if($user == 8 | $user == 130)
                            <td>{{ $clipper->quality_overall }}</td>
                            <td>{{ $clipper->interest_overall }}</td>
                            <td>{{ $clipper->discipline_overall }}</td>
                            <td>{{ $clipper->dedication_overall }}</td>
                        @endif

                        @if($clipper->overall == "A")
                            <td style="background: #8cd985">{{ $clipper->overall }}</td>
                        @elseif($clipper->overall == "B" | $clipper->overall == "C")
                            <td style="background: #fff8b3">{{ $clipper->overall }}</td>
                        @else
                            <td style="background: #f1b0b7">{{ $clipper->overall }}</td>
                        @endif

                        @if($user == 130)
                            <td>{{$clipper->increment_spm}}</td>
                        @endif

                        @if($user == 8)
                            <td>{{$clipper->increment_qpm}}</td>
                        @endif

                        @if($user == 5 | $user == 10)
                            <td>{{ $clipper->increment_qpm }}</td>
                            <td>{{ $clipper->increment_spm }}</td>
                            <td>{{ $clipper->increment_hr }}</td>
                            <td>{{ $clipper->increment_ho }}</td>
                        @endif

                        @if($user == 1)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="edit_efficiency" data-toggle="modal" data-target="#edit_efficiency" 
                                    data-production_test_id="{{$clipper->id}}" data-performance="{{$clipper->performance}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 5)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$clipper->id}}" data-name="{{$clipper->name}}" data-amount="{{$clipper->increment_ho}}" 
                                    data-remarks="{{$clipper->remarks_ho}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 130)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$clipper->id}}" data-name="{{$clipper->name}}" data-amount="{{$clipper->increment_spm}}" 
                                    data-remarks="{{$clipper->remarks_spm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 8)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="increment" data-toggle="modal" data-target="#increment"
                                    data-increment_id="{{$clipper->id}}" data-name="{{$clipper->name}}" data-amount="{{$clipper->increment_qpm}}" 
                                    data-remarks="{{$clipper->remarks_qpm}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 10)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="hr_feedback" data-toggle="modal" data-target="#hr_feedback"
                                    data-hr_increment_id="{{$clipper->id}}" data-name="{{$clipper->name}}" data-amount="{{$clipper->increment_hr}}" 
                                    data-remarks="{{$clipper->remarks_hr}}" data-salary="{{$clipper->salary}}" data-attendence="{{$clipper->attendence}}" 
                                    data-department="{{$clipper->department}}" data-date="{{$clipper->joining_date}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif

                        @if($user == 11 | $user == 12)
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="si_feedback" data-toggle="modal" data-target="#si_feedback" 
                                    data-si_increment_id="{{$clipper->id}}" data-designer_name="{{$clipper->name}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        @endif
                    </tr>
                @endforeach
            @endif
            
            @if($user == 1)
                @if($logs != null)
                    @foreach($logs as $log)
                        <tr>
                            <td>{{ $SL++ }}</td>
                            <td>{{ $log->Name }}</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td class="text-center" style="vertical-align:middle;">
                                <a href="#" class="add_efficiency" data-toggle="modal" 
                                    data-target="#add_efficiency" data-name="{{$log->Name}}" data-log_id="{{$log->id}}">
                                    <i class="fas fa-paper-plane text-primary" style="width: 20px; height: 20px"></i>
                                </a>
                            </td>
                        </tr>
                    @endforeach
                @endif
            @endif
        </table>

        <!-- Create Invoice Model-->
        @include('reader.modal.increment.increment')
        @include('reader.modal.increment.add_efficiency')
        @include('reader.modal.increment.edit_efficiency')
        @include('reader.modal.increment.si_feedback')
        @include('reader.modal.increment.hr_feedback')
        <br><br><br><br><br>
    </div>
@endsection
