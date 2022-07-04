<form class="form-inline justify-content-center" action="{{ route('admin_favorite') }}" method="GET">

    <label class="px-2">Minor : </label>
    <select class="form-control" style="width: 130px" name="user_id">
        <option value="{{ Request::get('user_id') }}">
            @if( Request::get('user_id') != null)
                {{ \App\User::find(Request::get('user_id'))->name }}
            @endif
        </option>
        <option value=""></option>
        @foreach($users as $user)
            <option value="{{$user->id}}"> {{$user->name}} </option>
        @endforeach
    </select>

    <label class="px-2">Possibility : </label>
    <select class="form-control" style="width: 130px" name="possibility_id">
        <option value="{{ Request::get('possibility_id') }}">
            @if( Request::get('possibility_id') != null)
                {{ \App\Possibility::find(Request::get('possibility_id'))->name }}
            @endif
        </option>
        <option value=""></option>
        @foreach($possibilities as $possibility)
            <option value="{{$possibility->id}}"> {{$possibility->name}} </option>
        @endforeach
    </select>

    <label class="px-2">Status : </label>
    <select class="form-control" style="width: 130px" name="status_id">
        <option value="{{ Request::get('status_id') }}">
            @if( Request::get('status_id') != null)
                {{ \App\Status::find(Request::get('status_id'))->name }}
            @endif
        </option>
        <option value=""></option>
        @foreach($statuses as $status)
            <option value="{{$status->id}}"> {{$status->name}} </option>
        @endforeach
    </select>

    <label class="px-1">Country : </label>
    <select class="form-control" style="width: 130px" name="country_id">
        <option value="{{ Request::get('country_id') }}">
            @if( Request::get('country_id') != null)
                {{ \App\Country::find(Request::get('country_id'))->name }}
            @endif
        </option>
        <option value=""></option>
        @foreach($countries as $country)
            <option value="{{$country->id}}"> {{$country->name}} </option>
        @endforeach
    </select>

    <label class="px-2">Catagory : </label>
    <select class="form-control" style="width: 130px" name="category_id">
        <option value="{{ Request::get('category_id') }}">
            @if( Request::get('category_id') != null)
                {{ \App\Category::find(Request::get('category_id'))->name }}
            @endif
        </option>
        <option value=""></option>
        @foreach($categories as $category)
            <option value="{{$category->id}}"> {{$category->name}} </option>
        @endforeach
    </select>

    <label class="px-2">From :</label>
    <input type="date" style="width: 160px" name="date" value="{{ Request::get('date') }}" class="form-control">

    <label class="px-2">To :</label>
    <input type="date" style="width: 160px" name="date_to" value="{{ Request::get('date_to') }}" class="form-control">

    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>
</form>
