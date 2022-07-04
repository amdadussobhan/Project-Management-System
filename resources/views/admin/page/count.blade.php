
<div id="Counter" class="container fixed-bottom">
    <div class="row ml-4">
        <div class="col-md-4 pr-5 bg-light border">
            <div class="row justify-content-center ml-3"><h3>Today's Count</h3></div>
            <div class="row">
                <div class="col">
                    {!! Form::open(['action'=>'AdminController@todays_leads', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <defs>
                                    <filter id="f1" x="0" y="0" width="200%" height="200%">
                                        <feOffset result="offOut" in="SourceGraphic" dx="5" dy="5" />
                                        <feGaussianBlur result="blurOut" in="offOut" stdDeviation="3" />
                                        <feBlend in="SourceGraphic" in2="blurOut" mode="normal" />
                                    </filter>
                                </defs>
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green"> {{$todays_leads}} </text>
                            </svg>
                            <h6 class="bg-light">Fresh Lead</h6>
                        </button>
                    {!! Form::close() !!}
                </div>

                <div class="col">
                    {!! Form::open(['action'=>'AdminController@todays_new_calls', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green"> {{$todays_new_calls}} </text>
                            </svg>
                            <h5 class="bg-light">New Call</h5>
                        </button>
                    {!! Form::close() !!}
                </div>

                <div class="col">
                    {!! Form::open(['action'=>'AdminController@todays_followup', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green"> {{$todays_followup}} </text>
                            </svg>
                            <h5 class="bg-light">Follow-Up</h5>
                        </button>
                    {!! Form::close() !!}
                </div>
            </div>
        </div>

        <div class="col-md-4 bg-light border pr-5" >
            <div class="row justify-content-center ml-3"><h3>This Week</h3></div>
            <div class="row">
                <div class="col">
                    {!! Form::open(['action'=>'AdminController@weekly_leads', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green" id="weekly_lead"> {{$weekly_leads}} </text>
                            </svg>
                            <h5 class="bg-light">Fresh Lead</h5>
                        </button>
                    {!! Form::close() !!}
                </div>

                <div class="col">
                    {!! Form::open(['action'=>'AdminController@weekly_new_calls', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green" id="weekly_lead"> {{$weekly_new_calls}} </text>
                            </svg>
                            <h5 class="bg-light">New Call</h5>
                        </button>
                    {!! Form::close() !!}
                </div>

                <div class="col">
                    {!! Form::open(['action'=>'AdminController@weekly_followup', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green" id="weekly_followup"> {{$weekly_followup}} </text>
                            </svg>
                            <h5 class="bg-light">Follow-Up</h5>
                        </button>
                    {!! Form::close() !!}
                </div>
            </div>
        </div>

        <div class="col-md-4 bg-light border pr-5">
            <div class="row justify-content-center ml-3"><h3>This Month</h3></div>
            <div class="row">
                <div class="col">
                    {!! Form::open(['action'=>'AdminController@monthly_leads', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green" id="monthly_lead"> {{$monthly_leads}} </text>
                            </svg>
                            <h5 class="bg-light">Fresh Lead</h5>
                        </button>
                    {!! Form::close() !!}
                </div>

                <div class="col">
                    {!! Form::open(['action'=>'AdminController@monthly_new_calls', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green" id="monthly_lead"> {{$monthly_new_calls}} </text>
                            </svg>
                            <h5 class="bg-light">New Call</h5>
                        </button>
                    {!! Form::close() !!}
                </div>

                <div class="col">
                    {!! Form::open(['action'=>'AdminController@monthly_followup', 'method'=>'GET']) !!}
                        <button type="submit" class="btn p-0 m-0">
                            <svg height="40" width="110">
                                <rect x="15" y="0" rx="10" ry="20" width="80" height="35" fill="rgb(222,222,222)"
                                      stroke="black" stroke-width="1" filter="url(#f1)" />
                                <text font-size="34" x="27" y="30" fill="green" id="monthly_followup"> {{$monthly_followup}} </text>
                            </svg>
                            <h5 class="bg-light">FollowUp</h5>
                        </button>
                    {!! Form::close() !!}
                </div>
            </div>
        </div>
    </div>
</div>
