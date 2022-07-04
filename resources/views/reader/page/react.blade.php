<td>
    {!! Form::open(['action'=>'ReactLeadController@store', 'method'=>'POST']) !!}
        <input type="hidden" name="lead_id" value="{{ $row->id}}">
        <input type="hidden" name="reactions" value="Like">
        <button class="btn p-0 m-0">
            <i class="fas fa-thumbs-up text-primary" style="width: 20px; height: 20px"></i>
        </button>
    {!! Form::close() !!}
</td>
<td>
    {!! Form::open(['action'=>'ReactLeadController@store', 'method'=>'POST']) !!}
        <input type="hidden" name="lead_id" value="{{ $row->id}}">
        <input type="hidden" name="reactions" value="Love">
        <button class="btn p-0 m-0">
            <i class="fas fa-heart text-danger" style="width: 20px; height: 20px"></i>
        </button>
    {!! Form::close() !!}
</td>
