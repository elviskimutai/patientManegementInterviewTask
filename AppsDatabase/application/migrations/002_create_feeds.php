<?php
class Migration_Create_feeds extends CI_Migration {

	public function up()
	{
		$this->dbforge->add_field(array(
			'id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
				'auto_increment' => TRUE
		),
			'user_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		),
			'image_path' => array(
				'type' => 'TEXT',		
		),
			'created' => array(
				'type' => 'DATETIME',
		),
			'modified' => array(
				'type' => 'DATETIME',
		),
			'caption' => array(
				'type' => 'TEXT',
		),

		));
		$this->dbforge->add_key('id');
		$this->dbforge->create_table('feeds');
	}

	public function down()
	{
		$this->dbforge->drop_table('feeds');
	}
}