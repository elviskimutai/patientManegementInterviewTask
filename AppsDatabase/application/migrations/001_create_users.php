<?php
class Migration_Create_users extends CI_Migration {

	public function up()
	{
		$this->dbforge->add_field(array(
			'id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
				'auto_increment' => TRUE
		),
			'first_name' => array(
				'type' => 'TEXT',		
		),
			'last_name' => array(
				'type' => 'TEXT',		
		),
			'phone' => array(
				'type' => 'TEXT',		
		),
			'username' => array(
				'type' => 'TEXT',		
		),
			'created' => array(
				'type' => 'DATETIME',
		),
			'modified' => array(
				'type' => 'DATETIME',
		),
			'website' => array(
				'type' => 'TEXT',
		),
			'bio' => array(
				'type' => 'TEXT',
		),
			'ppic' => array(
				'type' => 'TEXT',		
		),
			'status_text' => array(
				'type' => 'TEXT',
		),
			'status' => array(
				'type' => 'INT',
				'constraint' => 1,		
		)

		));
		$this->dbforge->add_key('id');
		$this->dbforge->create_table('users');
	}

	public function down()
	{
		$this->dbforge->drop_table('users');
	}
}