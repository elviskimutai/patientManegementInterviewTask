<?php
class Migration_Create_notifications extends CI_Migration {

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
			'comment_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		),
			'follower_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		),
			'created' => array(
				'type' => 'DATETIME',
		),
			'type' => array(
				'type' => 'DATETIME',
		),
			'status' => array(
				'type' => 'TEXT',
		),

		));
		$this->dbforge->add_key('id');
		$this->dbforge->create_table('notifications');
	}

	public function down()
	{
		$this->dbforge->drop_table('notifications');
	}
}