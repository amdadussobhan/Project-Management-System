
<?php
    $role = Auth::User()->role;
?>
<ul class="nav nav-pills justify-content-end">
    @if($role == 'admin' or $role == 'reader')
        <li class="nav-item pr-1"><a href="{{route('comments.index')}}" class="nav-link btn-outline-success"><b>Commentary</b></a></li>
    @endif
    @if($role == 'admin' or $role == 'writer')
        <li class="nav-item">
            <a href="#" class="nav-link btn-success" data-toggle="modal" data-target="#create_modal">
                <b>Create New Lead</b>
            </a>
        </li>
    @endif
    @if($role == 'reader')
        <li class="nav-item pr-1"><a href="{{route('activities')}}" class="nav-link btn-success"><b>Activities</b></a></li>
    @endif
</ul>
