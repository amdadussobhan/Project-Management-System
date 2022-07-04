
<ul class="nav nav-pills justify-content-center">
    <?php $role = Auth::User()->role; ?>
    @if($role == 'admin' or $role == 'writer' )
        <li>
            <a href="{{route('leads.edit', $single_lead->id)}}"><i class="fas fa-edit text-secondary mr-4" style="width: 25px; height: 25px"></i></a>
        </li>
{{--        <li>--}}
{{--            {!! Form::open(['action'=>['LeadController@destroy', $single_lead->id], 'method'=>'DELETE']) !!}--}}
{{--                <button class="btn p-0 m-0 delete_now">--}}
{{--                    <i class="fas fa-trash-alt text-danger mr-4" style="width: 25px; height: 25px"></i>--}}
{{--                </button>--}}
{{--            {!! Form::close() !!}--}}
{{--        </li>--}}
    @endif
    @if(Auth::User()->role == 'admin')
        <li>
            <a href="#" class="followup_show_page" data-toggle="modal" data-target="#Follow_Up" data-lead_id="{{$single_lead->id}}"
               data-possibility_id="@if($single_lead->possibility != null) {{$single_lead->possibility->id}} @endif"
               data-status_id="@if($single_lead->status != null) {{$single_lead->status->id}} @endif">
                <i class="fas fa-paper-plane text-primary" style="width: 25px; height: 25px"></i>
            </a>
        </li>
    @endif
</ul>
