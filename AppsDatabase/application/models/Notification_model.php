<?php
class notification_model extends MY_Model{

	protected $_table_name = 'notifications';
	protected $_order_by = 'name';
	
	protected $belongs_to = array('user', 'feed');
	
	function __construct (){
			parent::__construct();
			$this->_database = $this->db;
	}

	public function getUserNotification($user_id){
		$notifications = array();
		$notifications['comments'] = $this->getUserComements($user_id);
		$notifications['likes'] = $this->getUserLikes($user_id);
		return $notifications;
	}

	////////////////////////////////////////////////////////////////////////
	// Comments section
	////////////////////////////////////////////////////////////////////////

		public function getUserComements($user_id){
		$this->db->select('*');
		$this->db->from ( 'comments' );
		$this->db->where(array('user_id' => $user_id));
		$query = $this->db->get();
		$this->db->order_by('created','asc');
		$data = array();
		if ($query->num_rows() > 0){
			$comments = $query->result();
		   		foreach ($comments as $row){
		   			//get comments for each post
		   			$user = $this->getFeedUser($row->user_id);
		   			$row->user = $user;
		   		}
		   		return $comments;
		}else{
			$empty = array();
			return $empty;
		}
	}

		public function getFeedUser($user_id){
		$this->db->select('*');
		$this->db->from ( 'users' );
		$this->db->where(array('users.id' => $user_id));
		$query = $this->db->get();
		return $query->row();
	}
	////////////////////////////////////////////////////////////////////////
	// Likes section
	////////////////////////////////////////////////////////////////////////
	public function getUserLikes($user_id){
		$this->db->select('feeds.*');
		$this->db->from ( 'likes' );
		$this->db->join('feeds', ' feeds.id = likes.feed_id','left'); 
		$this->db->where(array('likes.user_id' => $user_id));
		$query = $this->db->get();
		return $query->result();
	}
	/////////////////////////////////////////////////////////////////////////
	// Trial section
	/////////////////////////////////////////////////////////////////////////
	public function getNotifications($user_id){
		$this->db->select('users.id');
		$this->db->from ( 'users' );
		$this->db->where(array('id' => $user_id));
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$notifications = $query->result();
		   		foreach ($notifications as $row){
		   			$comments = $this->getUserComements($row->id);
		   			$likes = array();
		   			$follow = array();
		   			$data['likes'] = $likes;
		   			$data['follow']	= $follow;   		
		   			$data['comments'] = $comments;
		   		}
		   		return $data;
		}else{
			$empty = array();
			return $empty;
		}
	}
}