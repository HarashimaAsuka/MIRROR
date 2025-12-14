using System.Collections;
using System.Collections.Generic;

public class ScoreManager
{
    private static ScoreManager mInstance;
    private int currentScore = 0;
    private int highScore = 0;

    public static ScoreManager Instance{
        get{
            if(mInstance == null){
                mInstance = new ScoreManager();
            }
            return mInstance;
        }
        set{

        }
    }

    public void initializeCurrentScore(){
        this.currentScore = 0;
    }

    public void addScore(int point){
        this.currentScore += point;
    }

    public int getCurrentScore(){
        return this.currentScore;
    }

    public int getHighScore(){
        return this.highScore;
    }

    public void compareHighScore(){
        if(this.currentScore > this.highScore)
            this.highScore = this.currentScore;
    }
}
