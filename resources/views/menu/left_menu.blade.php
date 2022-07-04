
<?php
    $role = Auth::User()->role;
?>
<ul class="nav nav-pills">
    @if($role == 'admin')
        <li class="nav-item pr-1"><a href="{{route('admin_followup')}}" class="nav-link btn-primary"><b>My Follow-Up</b></a></li>
        <li class="nav-item pr-1"><a href="{{route('admin_leads')}}" class="nav-link btn-outline-primary"><b>All Leads</b></a></li>
    @endif

    @if($role == 'writer')
        <li class="nav-item"><a href="{{route('writer_leads')}}" class="nav-link btn-primary"><b>All Leads</b></a></li>
    @endif

    @if($role == 'reader')
        <li class="nav-item pr-1"><a href="{{route('reader_leads')}}" class="nav-link btn-primary"><b>All Leads</b></a></li>
        <li class="nav-item pr-1"><a href="{{route('reader_new_call')}}" class="nav-link btn-outline-primary"><b>New Call</b></a></li>
{{--        <li class="nav-item pr-1"><a href="{{route('reader_followup_call')}}" class="nav-link btn-outline-primary"><b>Followup Call</b></a></li>--}}
        <li class="nav-item pr-1"><a href="{{route('reader_follow_up')}}" class="nav-link btn-outline-primary"><b>All Follow-Up</b></a></li>
    @endif
</ul>
