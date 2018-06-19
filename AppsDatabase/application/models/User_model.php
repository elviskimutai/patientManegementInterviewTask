<?php
class user_model extends MY_Model{

	protected $_table_name = 'users';
	protected $_order_by = 'name';

	protected $has_many = array('comments'=>array('primary_key'=>'user_id','model'=>'comment_model'), 'feeds'=>array('primary_key'=>'user_id','model'=>'feed_model'), 'likes'=>array('primary_key'=>'user_id','model'=>'like_model'));

	

		function __construct (){
				parent::__construct();
				$this->_database = $this->db;
		}

	public function login($email, $password){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where('username', $email);
		$this->db->where('password', $password);

		$query = $this->db->get();
		return $query->result();
	}

	public function logout () {
				$this->session->sess_destroy();
	}

	public function create($user){
		if (count($this->getUserByEmail($user['email'])) >= 1) {
			return 'email taken';
		} else {
			if (count($this->getUserByUsername($user['username'])) >= 1) {
				return 'username taken';
			}else{
				$id = $this->insert($user);
				return $this->get($id);
			}
		}
	}

	public function getUser2($current_user, $id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('id' => $id));

		$query = $this->db->get();
		if ($query->num_rows() > 0){
				$row = $query->row();
			      if (count($this->checkIfFollowing($current_user, $id))) {
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
			      }
			       return $row;
			}
			
		
	}

	public function searchUsers($current_user, $id, $search_term){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		//$this->db->where(array('id' => $id));
		$this->db->like('users.name', $search_term);
		$this->db->or_like('users.username', $search_term);
		$query = $this->db->get();
		if ($query->num_rows() > 0){
			$results = $query->result();
			foreach ($results as $row){
			      if (count($this->checkIfFollowing($current_user, $id))) {
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
			      }
			  }
			       return $results;
			}
			$empty = array();
			return $empty;
	}
	//ADD NOT current user
public function allUsers($current_user){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$query = $this->db->get();
		if ($query->num_rows() > 0){
			$results = $query->result();
			foreach ($results as $row){
			      if (count($this->checkIfFollowing($current_user, $row->id))) {
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
			      }
			  }
			       return $results;
			}else{
				$empty = array();
				return $empty;
			}
	}


	public function getUser($id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('id' => $id));

		$query = $this->db->get();
		return $query->result();
	}

	public function getUserByEmail($email){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('email' => $email));
		$query = $this->db->get();
		return $query->result();
	}
	public function getUserByUsername($username){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('username' => $username));
		$query = $this->db->get();
		return $query->result();
	}

	public function checkIfFollowing($follower_id, $followed_id){
		$this->db->select ( '*' );
		$this->db->from ( "followers" );
		$this->db->where(array('follower_id' => $follower_id));
		$this->db->where(array('followed_id' => $followed_id));
		$query = $this->db->get();
	return $query->result();
	}

	public function _unique_email ($str){
		// Do NOT validate if email already exists
		// UNLESS it's the email for the current user
		
		$id = $this->uri->segment(4);
		$this->db->where('email', $this->input->post('email'));
		!$id || $this->db->where('id !=', $id);
		$user = $this->user_m->get();
		
		if (count($user)) {
			$this->form_validation->set_message('_unique_email', '%s should be unique');
			return FALSE;
		}
		
		return TRUE;
	}
}