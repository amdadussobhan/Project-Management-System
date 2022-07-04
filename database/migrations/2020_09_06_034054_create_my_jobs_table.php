<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateMyJobsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('my_jobs', function (Blueprint $table) {
            $table->id();
            $table->integer('SL');
            $table->string('Loc');
            $table->dateTime('Date');
            $table->dateTime('StartTime');
            $table->dateTime('EndTime');
            $table->string('Name');
            $table->string('JobId');
            $table->string('Service');
            $table->string('Status');
            $table->integer('File')->nullable();
            $table->double('JobTime')->nullable();
            $table->double('ProTime')->nullable();
            $table->double('TotalJobTime')->nullable();
            $table->double('TotalProTime')->nullable();
            $table->integer('Efficiency')->nullable();
            $table->integer('Quality')->nullable();
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
        Schema::dropIfExists('my_jobs');
    }
}
