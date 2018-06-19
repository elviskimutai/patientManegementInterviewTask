<?php
class follower_model extends MY_Model{

	protected $_table_name = 'followers';
	protected $_order_by = 'name';
	protected $belongs_to = array('user');

	// protected $has_many = array('users'=>array('primary_key'=>'user_id'));
	// protected $has_many = array('feeds'=>array('primary_key'=>'user_id'));
	// protected $has_many = array('comments'=>array('primary_key'=>'user_id'));
	// protected $has_many = array('followers'=>array('primary_key'=>'user_id'));
	// protected $has_many = array('likes'=>array('primary_key'=>'user_id'));
	
	function __construct (){
			parent::__construct();
			$this->_database = $this->db;
		}


	public function checkIfFollowing($follower_id, $followed_id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('follower_id' => $follower_id));
		$this->db->where(array('followed_id' => $followed_id));
		$query = $this->db->get();
	return $query->result();
	}

	public function checkIfFollowing2($follower_id, $followed_id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('follower_id' => $follower_id));
		$this->db->where(array('followed_id' => $followed_id));
		$query = $this->db->get();
		if (count($query->result())>0) {
			return $query->row()->id;
		}else{
			return 0;
		}
	
	}

	public function follow($follow){
		if (count($this->checkIfFollowing($follow['follower_id'], $follow['followed_id'])) >= 1) {
			return 'Already following';
		} else {
				$id = $this->insert($follow);
				return 'Followed successfully';
		}
	}

	public function unfollow($follow){
		if ($this->checkIfFollowing2($follow['follower_id'], $follow['followed_id']) >= 1) {
			$id = $this->checkIfFollowing2($follow['follower_id'], $follow['followed_id']);
				$this->delete($id);
				return 'unFollowed successfully';
		} else {
			return 'Not following';
				
		}
	}

	public function getUserFollowersCount($user_id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('followed_id' => $user_id));
		$query = $this->db->get();
		$total = count($query->result());
		return $total;
	}

		public function checkIfExists($user_id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('id' => $user_id));
		$query = $this->db->get();
		$total = count($query->result());
		return $total;
	}

	public function getUserFollowingCount($user_id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('follower_id' => $user_id));
		$query = $this->db->get();
		$total = count($query->result());
		return $total;
	}

	public function getUserFollowers($current_user, $user_id){
		$this->db->select ( 'users.*' );
		$this->db->from ( $this->_table_name );
		$this->db->join('users', ' users.id = followers.follower_id','left'); 
		$this->db->where(array('followed_id' => $user_id));
		$this->db->distinct();
		$query = $this->db->get();
		$data = array();
			if ($query->num_rows() > 0){
				$followers = $query->result();
		   foreach ($followers as $row){
		      if (count($this->checkIfFollowing($current_user, $user_id))>0) {
			      $row->id;
			      $row->name;
			      $row->phone;
			      $row->username;
			      $row->created;
			      $row->modified;
			      $row->website;
			      $row->bio;
			      $row->ppic;
			      $row->status_text;
			      $row->status;
			      $row->email;
			      $row->password;
			      $row->registration_gcm_id;
			      $row->isFollowing  = 'true';
			      array_push($data, $row);
		      }else{
		      	  $row->id;
			      $row->name;
			      $row->phone;
			      $row->username;
			      $row->created;
			      $row->modified;
			      $row->website;
			      $row->bio;
			      $row->ppic;
			      $row->status_text;
			      $row->status;
			      $row->email;
			      $row->password;
			      $row->registration_gcm_id;
			      $row->isFollowing  = 'false';
			      array_push($data, $row);
		      }
		   }
		}
		return $data;
	}

		public function getUserFollowing($current_user, $user_id){
		$this->db->select ( 'users.*' );
		$this->db->from ( $this->_table_name );
		$this->db->join('users', ' users.id = followers.followed_id'); 
		$this->db->where(array('followers.follower_id' => $user_id));
		//$this->db->distinct();
		$query = $this->db->get();
		$data = array();
			if ($query->num_rows() > 0){
				$followers = $query->result();
		   foreach ($followers as $row){
		      if (count($this->checkIfFollowing($current_user, $row->id))>0) {
			      $row->id;
			      $row->name;
			      $row->phone;
			      $row->username;
			      $row->created;
			      $row->modified;
			      $row->website;
			      $row->bio;
			      $row->ppic;
			      $row->status_text;
			      $row->status;
			      $row->email;
			      $row->password;
			      $row->registration_gcm_id;
			      $row->isFollowing  = 'true';
			      array_push($data, $row);
		      }else{
		      	  $row->id;
			      $row->name;
			      $row->phone;
			      $row->username;
			      $row->created;
			      $row->modified;
			      $row->website;
			      $row->bio;
			      $row->ppic;
			      $row->status_text;
			      $row->status;
			      $row->email;
			      $row->password;
			      $row->registration_gcm_id;
			      $row->isFollowing  = 'false';
			      array_push($data, $row);
		      }
		   }
		}
		return $data;
	}
}