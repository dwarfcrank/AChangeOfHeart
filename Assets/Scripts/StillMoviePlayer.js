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
        Debug.Log(p);
        movie_stills[i] = Resources.Load(p) as Texture;
        Debug.Log(movie_stills[i]);
    }
}

function Update ()
{
    if(play == true)
    {
        Player();
    }
}

private var cur_still = 0;

function Player(){

    play = false;

    if(cur_still < number_of_stills)
    {
        var MainTex = movie_stills[cur_still];

        renderer.material.SetTexture("_MainTex", MainTex);

        cur_still += 1;

        var fps_fixer = fps*3;

        var wait_time = 1.0/fps_fixer;

        yield WaitForSeconds(wait_time);
    }

    play = true;

}