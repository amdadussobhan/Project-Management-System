@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing WorkOrder</h3>
@endsection

@section('content')
    <div class="container">
    <a href="{{ route('itemPdfView',['download'=>'pdf']) }}">Download PDF</a>   
        <table class="table table-bordered">  
            <tr>  
                <th>No</th>  
                <th>Name</th>  
                <th>Price</th>  
            </tr>  
            @foreach ($items as $key => $item)  
                <tr>  
                    <td>{{ ++$key }}</td>  
                    <td>{{ $item->name }}</td>  
                    <td>{{ $item->ref_id }}</td>  
                </tr>  
            @endforeach
        </table>  
    </div>
@endsection