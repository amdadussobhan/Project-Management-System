<?php

use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Route;
Auth::routes();

Route::group(['prefix'=>'/1', 'middleware'=>['auth', 'admin']], function(){
    Route::get('dashboard', ['as'=>'admin_dashboard', 'uses'=>'AdminController@dashboard']);
});

Route::group(['prefix'=>'/2', 'middleware'=>['auth', 'writer']], function(){
    Route::get('dashboard', ['as'=>'writer_dashboard', 'uses'=>'HomeController@check_user']);
});

Route::group(['prefix'=>'/3', 'middleware'=>['auth', 'reader']], function(){
    Route::get('dashboard', ['as'=>'reader_dashboard', 'uses'=>'ReaderController@dashboard']);
    Route::get('workloads', ['as'=>'reader_workloads', 'uses'=>'ReaderController@workloads']);
    Route::get('shift_report', ['as'=>'reader_shift_report', 'uses'=>'ReaderController@shift_report']);
    Route::get('shift_reports', ['as'=>'reader_shift_reports', 'uses'=>'ReaderController@shift_reports']);
    Route::get('performance', ['as'=>'reader_performance', 'uses'=>'ReaderController@performance']);
    Route::get('performances', ['as'=>'reader_performance', 'uses'=>'ReaderController@performances']);
    Route::get('attendence', ['as'=>'reader_attendence', 'uses'=>'ReaderController@attendence']);
    Route::get('designer', ['as'=>'reader_designer', 'uses'=>'ReaderController@designer']);
    Route::get('job', ['as'=>'reader_job', 'uses'=>'ReaderController@job']);
    Route::get('jobs', ['as'=>'reader_jobs', 'uses'=>'ReaderController@jobs']);
    Route::get('pending_jobs', ['as'=>'reader_pending_jobs', 'uses'=>'ReaderController@pending_jobs']);
    Route::get('production_error', ['as'=>'reader_production_error', 'uses'=>'ReaderController@production_error']);
    Route::get('productivity', ['as'=>'reader_productivity', 'uses'=>'ReaderController@productivity']);
    Route::get('qc_report', ['as'=>'reader_qc_report', 'uses'=>'ReaderController@qc_report']);
    Route::get('revenue', ['as'=>'reader_revenue', 'uses'=>'ReaderController@revenue']);

    Route::get('test_report', 'ProductionTestController@test_report');
    Route::get('production_test', 'ProductionTestController@production_test');
    Route::get('production_tests', 'ProductionTestController@production_tests');
    Route::get('production_test_print', 'ProductionTestController@production_test_print');
    Route::post('production_test_add_efficiency', 'ProductionTestController@add_efficiency');
    Route::post('production_test_edit_efficiency', 'ProductionTestController@edit_efficiency');
    Route::post('production_test_si_feedback', 'ProductionTestController@si_feedback');
    Route::post('production_test_hr_feedback', 'ProductionTestController@hr_feedback');
    Route::post('production_test_increment', 'ProductionTestController@increment');
});

Route::group(['prefix'=>'/4', 'middleware'=>['auth', 'accounts']], function(){
    Route::get('dashboard', ['as'=>'accounts_dashboard', 'uses'=>'AccountController@dashboard']);
    Route::get('workorder/{workorder}', ['as'=>'accounts_workorder', 'uses'=>'AccountController@workorder']);
    Route::get('workorders', ['as'=>'accounts_workorders', 'uses'=>'AccountController@workorders']);
    Route::get('/print/workorder/{workorder}', ['as'=>'print_workorder', 'uses'=>'WorkorderController@print']);
});

Route::group(['prefix'=>'/', 'middleware'=>['auth', 'admin_writer_reader']], function(){

});

Route::group(['prefix'=>'/', 'middleware'=>['auth', 'admin_reader']], function(){

});

Route::group(['prefix'=>'/', 'middleware'=>'auth'], function(){
    Route::get('/home', 'HomeController@index');

    Route::resource('workorder', 'WorkorderController');
    Route::resource('invoice', 'InvoiceController');
    Route::resource('productin_test', 'ProductionTestController');

    Route::get('/client', ['as'=>'client', 'uses'=>'WorkorderController@client']);
    Route::get('/workorder/pdf/{workorder}', ['as'=>'workorder_pdf', 'uses'=>'WorkorderController@CreatePDF']);
    Route::get('/downloadPDF/{workorder}','WorkorderController@downloadPDF');
    Route::get('itemPdfView', array('as'=>'itemPdfView','uses'=>'WorkorderController@itemPdfView'));
    Route::get('generate-pdf', 'WorkorderController@generatePDF');
    Route::post('productin_test', 'ProductionTestController@modify');
});

Route::get('/', 'HomeController@index');
