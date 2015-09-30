<?php
class Upload extends CI_Controller {

	public function index()
	{
    	$config['upload_path'] = './uploads/';
		$config['allowed_types'] = 'gif|jpg|png';
		$config['max_size']	= '10000';
		$config['max_width']  = '1920';
		$config['max_height']  = '1920';

		$this->load->library('upload', $config);


		//For a expecific file
		//if needed try to upload everithing
		//if ( ! $this->upload->do_upload())

		if ( ! $this->upload->do_upload('image'))
		{
			$data = array('error' => $this->upload->display_errors());
		}
		else
		{
			$data = array('upload_data' => $this->upload->data());

		}

		echo json_encode($data);

	}
}
?>
