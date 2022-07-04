<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateLogsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('logs', function (Blueprint $table) {
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
            $table->double('ActualTime')->nullable();
            $table->double('TargetTime')->nullable();
            $table->double('ProTime')->nullable();
            $table->string('Image');
            $table->string('Remarks')->nullable();
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
        Schema::dropIfExists('logs');
    }
}
