var number_of_stills = 1;
private var movie_stills = new Array();
var path = "";
var fps = 24;

private var play = true;

function Start()
{
    for(var i = 0; i < number_of_stills; i++)
    {
        var s = "" + (i+1);
        while(s.length < 4)
        {
            s = "0" + s;
        }

        var p = path + s;
        movie_stills[i] = Resources.Load(p) as Texture;
    }
}

function Update ()
{
    if(Input.anyKeyDown)
    {
        Application.LoadLevel("mainLevel");
    }        

    if(play == true)
    {
        Player();
    }
}

private var cur_still = 0;

var trunk_sound: AudioSource;
var crash_sound: AudioSource;
var start_sound: AudioSource;

function Player(){

    play = false;

    if(cur_still < number_of_stills)
    {
        var MainTex = movie_stills[cur_still];
        renderer.material.SetTexture("_MainTex", MainTex);
        var wait_time = 1.0/fps;

        yield WaitForSeconds(wait_time);

        cur_still += 1;
        if(cur_still == number_of_stills)
        {
            Application.LoadLevel("mainLevel");
        }

        if(cur_still == 184 || cur_still == 197)
        {
            trunk_sound.Play();
        }
        else if(cur_still == 200)
        {
            start_sound.Play();
        }
        else if(cur_still == 190)
        {
            crash_sound.Play();
        }
    }

    play = true;
}