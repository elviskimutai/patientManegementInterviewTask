<?php
class User extends CI_Controller
{

	public function __construct ()
	{
		parent::__construct();
		$this->load->model('user_model');
	}

	
	public function edit ($id = NULL){
		// Fetch a user or set a new one
		if ($id) {
			$this->data['user'] = $this->user_model->get($id);
			count($this->data['user']) || $this->data['errors'][] = 'User could not be found';
		}
		else {
			$this->data['user'] = $this->user_model->get_new();
		}
		
		// Set up the form
		$rules = $this->user_model->rules_admin;
		$id || $rules['password']['rules'] .= '|required';
		$this->form_validation->set_rules($rules);
		
		// Process the form
		if ($this->form_validation->run() == TRUE) {
			$data = $this->user_model->array_from_post(array('name', 'email', 'password'));
			$data['password'] = $this->user_model->hash($data['password']);
			$this->user_model->save($data, $id);
			redirect('admin/user');
		}
	}
		

	
	public function login (){
		
		//$email = $this->input->post('email');
		$username = $this->input->post('username');
		$password = $this->input->post('password');

		$data = $this->user_model->login($username, $password);

		$user = array();

		if(  $data != false) {
			if ($data[0] != null) {
				$user['user'] = $data[0];
				$user['message'] = 'Success';
				$user['success'] = true;
			} else {
				$user['success'] = false;
				$user['message'] = 'Something went wrong';
				$user['user'] = null;
			}
		}else{
			$user['success'] = false;
			$user['message'] = 'email or password is incorrect';
			$user['user'] = null;
		}

		echo json_encode($user);

	}

	public function logout (){
		$this->user_model->logout();
	}
	
	     public function uploadPpic(){
        	
        	$data = $this->input->post('image');
        	$image_name = $this->input->post('image_name');
			$data = base64_decode($data);
		
			$file = 'assets/profile_pictures/'. uniqid() .'_'.$image_name. '.png';
			$image_name = site_url().$file;
			$success = file_put_contents($file, $data);
			
			$feed = array();
		if($success) {

			$feed['message'] = 'Success';
			$feed['success'] = true;
			$feed['image_url'] = $image_name;
			
		}else{
			$feed['success'] = false;
			$feed['message'] = 'Something went wrong';
			//$feed['feed'] = array();
		}

		echo json_encode($feed);
      }

	public function _unique_email ($str){
		// Do NOT validate if email already exists
		// UNLESS it's the email for the current user
		
		$id = $this->uri->segment(4);
		$this->db->where('email', $this->input->post('email'));
		!$id || $this->db->where('id !=', $id);
		$user = $this->user_model->get();
		
		if (count($user)) {
			$this->form_validation->set_message('_unique_email', '%s should be unique');
			return FALSE;
		}
		
		return TRUE;
	}

              
		public function register(){
		$userd = array(
			"username" => $this->input->post('username'),
			"email" => $this->input->post('email'),
			"name" => $this->input->post('name'),
			"website" => $this->input->post('website'),
			"bio" => $this->input->post('bio'),
			"password" => $this->input->post('password'),
			"status_text" => $this->input->post('status_text'),
			"ppic" => $this->input->post('ppic'),
			"status" => 0,
			"isFollowing" => 'false',
			//"isFollowing"=>$this->input->post('isFollowing'),
			"registration_gcm_id"=>$this->input->post('registration_gcm_id')
		);

		$data = $this->user_model->create($userd);
		$user = array();
		if ($data=='username taken') {
			$user['success'] = false;
			$user['message'] = 'username is already taken';
			$user['user'] = null;
		}elseif ($data=='email taken') {
			$user['success'] = false;
			$user['message'] = 'email is already taken';
			$user['user'] = null;
		}else{
			$user['user'] = $data;
			$user['message'] = 'Success';
			$user['success'] = true;
		}
		echo json_encode($user);
	}

	public function getUser(){
		$user_id = $this->input->post('id');
		$current_user = $this->input->post('current_user');
		$data = $this->user_model->getUser2($current_user, $user_id);
		$user = array();
		if(  $data != null) {
				$user['user'] = $data;
				$user['message'] = 'Success';
				$user['success'] = true;
			} else {
				$user['success'] = false;
				$user['message'] = 'Something went wrong';
				$user['user'] = null;
		}

		echo json_encode($user);
	}

	public function searchUsers(){
		$user_id = $this->input->post('id');
		$current_user = $this->input->post('current_user');
		$search_term = $this->input->post('search_term');
		$results = $this->user_model->searchUsers($current_user, $user_id, $search_term);
		$user = array();
		if(  $results != null) {
				$user['users'] = $results;
				$user['message'] = 'Success';
				$user['success'] = true;
			} else {
				$empty = array();
				$user['success'] = false;
				$user['message'] = 'Something went wrong';
				$user['users'] = $empty;
		}

		echo json_encode($user);
	}

	public function allUsers(){
		$current_user = $this->input->post('current_user');
		$results = $this->user_model->allUsers($current_user);
		$user = array();
		if(  $results != null) {
				$user['users'] = $results;
				$user['message'] = 'Success';
				$user['success'] = true;
			} else {
				$empty = array();
				$user['success'] = false;
				$user['message'] = 'Something went wrong';
				$user['users'] = $empty;
		}

		echo json_encode($user);
	}
}