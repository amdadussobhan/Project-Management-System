@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing WorkOrder</h3>
@endsection

@section('content')
    <div class="container">     
        <table class="table table-bordered">
            <tr>
                <td>
                {{$user->skill_code}}
                </td>
                <td>
                {{$user->address}}
                </td>
            </tr>
            <tr>
                <td>
                {{$user->ref_id}}
                </td>
                <td>
                {{$user->name}}
                </td>
            </tr>
        </table>
    </div>
@endsection