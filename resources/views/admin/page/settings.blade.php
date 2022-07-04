@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Settings</h3>
@endsection
<?php $role = Auth::User()->role; ?>

@section('content')
    <div class="container">
        <div class="row align-items-center">
            <div class="col-md-6 mb-2">
                @include('menu.left_menu')
            </div>
            <div class="col-md-6 mb-2">
                @include('menu.right_menu')
            </div>
        </div>
        <hr>
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title d-inline">Possibility</h4>
                        <a href="{{route('possibility.index')}}"><i class="float-right fas fa-cog fa-2x"></i></a>
                    </div>
                    <div class="card-body">
                        <?php $possibilities = App\Possibility::all() ?>
                        <ol>
                            @foreach($possibilities as $possibilitiy)
                                <li>{{$possibilitiy->name}}</li>
                            @endforeach
                        </ol>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title d-inline">Category</h4>
                        <a href="{{route('category.index')}}"><i class="float-right fas fa-cog fa-2x"></i></a>
                    </div>
                    <div class="card-body">
                        <?php $categories = App\Category::all() ?>
                        <ol>
                            @foreach($categories as $category)
                                <li>{{$category->name}}</li>
                            @endforeach
                        </ol>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title d-inline">Status Types</h4>
                        <a href="{{route('status.index')}}"><i class="float-right fas fa-cog fa-2x"></i></a>
                    </div>
                    <div class="card-body">
                        <?php $statuses = App\Status::all() ?>
                        <ol>
                            @foreach($statuses as $status)
                                <li>{{$status->name}}</li>
                            @endforeach
                        </ol>
                    </div>
                </div>
            </div>

        </div>
        <br>
        <div class="row">

            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title d-inline">Country</h4>
                        <a href="{{route('country.index')}}"><i class="float-right fas fa-cog fa-2x"></i></a>
                    </div>
                    <div class="card-body">
                        <?php $countries = App\Country::all() ?>
                        <ol>
                            @foreach($countries as $country)
                                <li>{{$country->name}}</li>
                            @endforeach
                        </ol>
                    </div>
                </div>
            </div>

        </div>
        <br>
        @include('leads.create_lead_modal')
        <br><br><br><br><br><br>
    </div>
@endsection
