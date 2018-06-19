<?php
class Migration_Create_comments extends CI_Migration {

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
			'feed_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		),
			'created' => array(
				'type' => 'DATETIME',
		),
			'modified' => array(
				'type' => 'DATETIME',
		),
			'comment' => array(
				'type' => 'TEXT',
		),

		));
		$this->dbforge->add_key('id');
		$this->dbforge->create_table('comments');
	}

	public function down()
	{
		$this->dbforge->drop_table('comments');
	}
}