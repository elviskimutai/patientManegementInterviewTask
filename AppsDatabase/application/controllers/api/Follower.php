<?php
class Follower extends CI_Controller
{

	public function __construct ()
	{
		parent::__construct();
		$this->load->model('follower_model');
		$this->load->model('user_model');
	}


	public function follow(){
		$follow = array(
			"follower_id" => $this->input->post('follower_id'),
			"followed_id" => $this->input->post('followed_id')
		);

		$data = $this->follower_model->follow($follow);
		$feed = array();

		if( $data=='Already following') {
			$feed['success'] = false;
			$feed['message'] = 'Already following the user';
			
		}else if($data == 'Followed successfully'){
			$feed['message'] = 'Followed successfully';
			$feed['success'] = true;
		}else{
			$feed['message'] = 'Something went wrong';
			$feed['success'] = false;
			
		}

		echo json_encode($feed);
	}

	public function unfollow(){
		$follow = array(
			"follower_id" => $this->input->post('follower_id'),
			"followed_id" => $this->input->post('followed_id')
		);
		$data = $this->follower_model->unfollow($follow);
		$feed = array();

		if( $data=='Not following') {
			$feed['success'] = false;
			$feed['message'] = 'Not following the user';
			
		}else if($data == 'unFollowed successfully'){
			$feed['message'] = 'unFollowed successfully';
			$feed['success'] = true;
		}else{
			$feed['message'] = 'Something went wrong';
			$feed['success'] = false;
		}

		echo json_encode($feed);
	}

	public function followersCount(){
		$followed_id = $this->input->post('user_id');
		$data = $this->follower_model->getUserFollowersCount($followed_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['follow'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['follow'] = 0;
			
		}

		echo json_encode($feed);
	}

	public function followingCount(){
		$followed_id = $this->input->post('user_id');
		$data = $this->follower_model->getUserFollowingCount($followed_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['follow'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['follow'] = 0;
			
		}

		echo json_encode($feed);
	}
	public function followers(){
		$followed_id = $this->input->post('user_id');
		$current_user = $this->input->post('current_user');
		$data = $this->follower_model->getUserFollowers($current_user, $followed_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['user'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['user'] = array();
			
		}

		echo json_encode($feed);
	}

	public function following(){
		$following_id = $this->input->post('user_id');
		$current_user = $this->input->post('current_user');
		$data = $this->follower_model->getUserFollowing($current_user, $following_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['user'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['user'] = array();
			
		}

		echo json_encode($feed);
	}
}

	