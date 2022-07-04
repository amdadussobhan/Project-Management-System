@extends('layouts.app')
@section('Head')
    <!-- <h3 class="text-white">Dashboard</h3> -->
@endsection
<?php
    use Illuminate\Support\Facades\Auth;
    $role = Auth::User()->role; 
?>

@section('content')
    <div class="container">
        <strong>
            <div class="row ">
                <div class="col mb-2 bg-light">
                    @include('admin.menu.center_menu')
                </div>
            </div>
        </strong>
        
        <div class="row align-items-center">
            <div class="col-2 mb-2">
                <ul class="nav nav-pills">
                    <li class="nav-item pr-1">
                        <a href="#" class="nav-link btn btn-outline-primary create_item_click" data-invoice_id="{{ $invoice->id }}" data-toggle="modal" data-target="#create_modal">
                            <b>+ Add Item</b>
                        </a>
                    </li>
                </ul>
            </div>
            <div class="col mb-2 ">
                <ul class="nav nav-pills float-right">
                    <li class="nav-item pr-1">
                        <a href=" {{ route('print_invoice', $invoice->id) }} " target="_blank" class="nav-link btn btn-outline-primary">
                            <b>Print Now</b>
                        </a>
                    </li>
                </ul>
            </div>
        </div>

        <table class="table mb-0">
            <thead class="text-center">
                <tr><td><h2 class="mr-5">INVOICE</h2></td></tr>
            </thead>
        </table>

        <div class="row mb-3">
            <div class="col">
                <h6>Invoice To,</h5>
                <h5> {{ $invoice->company->name }} </h5>
                <h6> {{ $invoice->company->address }} </h6>
            </div>
            <div class="col mx-5">
            </div>
            <div class="col ml-5">
                <h6>Invoice No: {{ $invoice->sl }} </h6>
                <h6>Invoice Date: {{ date('d-M-Y', strtotime($invoice->invoice_date)) }} </h6>
                <h6>PO No: {{ $invoice->sl }} </h6>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col">
                <h6>Attention : {{ $invoice->company->contact_person }}</h6>
                <h6>Designation : {{ $invoice->company->designation }}</h6>
                <h6>Phone : {{ $invoice->company->phone }}</h6>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col">
                <h6>Subject: Invoice for {{ $invoice->name }}</h6>
            </div>
        </div>

        <table class="table table-bordered table-striped table-sm">
            <thead class="text-center">
                <th>SL</th>
                <th>Particulars</th>
                <th>Details</th>
                <th>Quantity</th>
                <th>Unit Price</th>
                <th>Total Price</th>
                <th>Total VAT</th>
                <th>Grand Total</th>
                <th colspan="2">Action</th>
            </thead>
            <?php $SL = 1; $total_price = 0; $total_vat = 0; $grand_total = 0; ?>
            @if($rows != null)
            @foreach($rows as $row)
                <tr>
                    <td class="text-center" style="vertical-align:middle;">{{ $SL++ }}</td>
                    <td class="text-center" style="vertical-align:middle;"><a href=" {{ route('invoice_item', $row->id) }} ">{{$row->name}}</a></td>
                    <td class="text-center" style="vertical-align:middle;">{{ $row->details }}</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $row->quantity }}</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $row->unit_price }}</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $row->total_price }}</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $row->total_vat }}</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $row->grand_total }}</td>

                    <td class="text-center" style="vertical-align:middle;">
                        <a href="#" class="followup_lead_page" data-toggle="modal" data-target="#Follow_Up" data-lead_id="{{$row->id}}"
                           data-possibility_id="@if($row->possibility != null) {{$row->possibility->id}} @endif"
                           data-status_id="@if($row->status != null) {{$row->status->id}} @endif">
                            <i class="fas fa-pencil-alt text-primary" style="width: 20px; height: 20px"></i>
                        </a>
                    </td>

                    <td class="text-center" style="vertical-align:middle;">
                        <a href="#" class="followup_lead_page" data-toggle="modal" data-target="#Follow_Up" data-lead_id="{{$row->id}}"
                           data-possibility_id="@if($row->possibility != null) {{$row->possibility->id}} @endif"
                           data-status_id="@if($row->status != null) {{$row->status->id}} @endif">
                            <i class="fas fa-trash-alt text-danger" style="width: 20px; height: 20px"></i>
                        </a>
                    </td>

                    <?php $total_price += $row->total_price; $total_vat += $row->total_vat;  $grand_total += $row->grand_total; ?>
                </tr>
            @endforeach            
                <tr class="font-weight-bold bg-light">
                    <td class="text-right" style="vertical-align:middle;" colspan="5">Grand Total :</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $total_price }}</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $total_vat }}</td>
                    <td class="text-center" style="vertical-align:middle;">{{ $grand_total }}</td>
                    <td class="text-right" style="vertical-align:middle;" colspan="2"></td>
                </tr>                    
            @endif
        </table>

        <div class="row mt-3">
            <div class="col">
                <h5>Tarms & Conditions	</h5>
            </div>
        </div>

        <div class="row">
            <div class="col ml-5">
                <h6>1	Custom Text</h6>
                <h6>2	Custom Text</h6>
                <h6>3	Custom Text</h6>
            </div>
        </div>

        <div class="row mt-5">
            <div class="col">
            <h5>For Payment, Bank details are given below</h5>
            <h6>Account Title: X SOLUTIONS LIMITED</h6>
            <h6>Account Number: 1401886525001</h6>
            <h6>Bank Name:The City Bank Limited</h6>
            <h6>Routing Number: 225261729</h6>
            <h6>Bank Address: United House, 10 Gulshan Avenue, Dhaka 1212</h6>
            </div>
        </div>
        
        <div class="row my-5">
            <div class="col">
                <h5>Initiated By</h5>
                <h5>Name: {{ $invoice->creator->name }} </h5>
                <h6>Designation: {{ $invoice->creator->designation }} </h6>
                <h6>Phone No : {{ $invoice->creator->phone }} </h6>
            </div>

            <div class="col">
            </div>

            <div class="col ml-5">
                <h5>Approved By</h5>
                @if($invoice->approver != null)
                    <h5>Name: {{ $invoice->approver->name }} </h5>
                    <h6>Designation: {{ $invoice->approver->designation }} </h6>
                    <h6>Phone Number: {{ $invoice->approver->phone }} </h6>
                @else
                    <h5>Name: </h5>
                    <h6>Designation:  </h6>
                    <h6>Phone No : </h6>
                @endif
            </div>
        </div>
        
        <!-- Create Invoice Model-->
        @include('admin.modal.create_invoice_item')
        <br><br><br><br><br>
    </div>
@endsection
