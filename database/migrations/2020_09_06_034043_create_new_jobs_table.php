<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateNewJobsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('new_jobs', function (Blueprint $table) {
            $table->id();
            $table->integer('SL');
            $table->string('Loc');
            $table->dateTime('Date');
            $table->string('JobId');
            $table->string('Client');
            $table->string('Category');
            $table->string('Service');
            $table->string('Status');
            $table->string('Type');
            $table->dateTime('Incoming');
            $table->dateTime('Delivery');
            $table->integer('InputAmount')->nullable();
            $table->integer('ProDone')->nullable();
            $table->integer('OutputAmount')->nullable();
            $table->double('Price')->nullable();
            $table->double('Taka')->nullable();
            $table->string('Currency')->nullable();
            $table->double('ActualTime')->nullable();
            $table->double('TargetTime')->nullable();
            $table->double('ProTime')->nullable();
            $table->double('QcTime')->nullable();
            $table->integer('ActualEfficiency')->nullable();
            $table->integer('TargetEfficiency')->nullable();
            $table->string('Receiver')->nullable();
            $table->string('Sender')->nullable();
            $table->string('SiName')->nullable();
            $table->string('QcName')->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('new_jobs');
    }
}
