import os
import sys
import pandas as pd
from tensorflow import keras
from sklearn.preprocessing import MinMaxScaler
pd.plotting.register_matplotlib_converters()
# %matplotlib inline
#TODO 

fifa22df = pd.read_csv('E:/Desktop/Onlab2/fifa22df.csv')
fifa22df = fifa22df.drop(labels = 'Unnamed: 0', axis = 1)

neuralmodelraw = keras.models.load_model('E:/Desktop/Onlab2/my_model')
probability_model = keras.models.Sequential([
                                             neuralmodelraw,
                                             keras.layers.Softmax()
])

#TODO 
X = pd.read_csv('E:/Desktop/Onlab2/X.csv')
X = X.drop(labels = 'Unnamed: 0', axis = 1)


def correctodds(a, b, c, d):
    teljesesemenyter = 1/a + 1/b +1/c
    corrodds =1/((1/d) / teljesesemenyter)
    return corrodds


def evaluate(h, d, a, hometeam, awayteam):
  hometeamdf = fifa22df.drop(fifa22df.index)
  awayteamdf = fifa22df.drop(fifa22df.index)
  
  if( h == -1):
    return 
  for idx in fifa22df.index: 
    if fifa22df.loc[idx, 'name'] == hometeam:
      hometeamdf.loc[len(hometeamdf)] = fifa22df.loc[idx]
    if fifa22df.loc[idx, 'name'] == awayteam:
      awayteamdf.loc[len(awayteamdf)] = fifa22df.loc[idx]

  diff = [  
    hometeamdf.loc[0, 'overall'] - awayteamdf.loc[0, 'overall'],
    hometeamdf.loc[0, 'AttackingRating'] - awayteamdf.loc[0, 'AttackingRating'],
    hometeamdf.loc[0, 'MidfieldRating'] - awayteamdf.loc[0, 'MidfieldRating'],
    hometeamdf.loc[0, 'DefenceRating'] - awayteamdf.loc[0, 'DefenceRating'],
    hometeamdf.loc[0, 'XIAverageAge'] - awayteamdf.loc[0, 'XIAverageAge'],
    hometeamdf.loc[0, 'DefenceWidth'] - awayteamdf.loc[0, 'DefenceWidth'],
    hometeamdf.loc[0, 'DefenceDepth'] - awayteamdf.loc[0, 'DefenceDepth'],
    hometeamdf.loc[0, 'OffenceWidth'] - awayteamdf.loc[0, 'OffenceWidth'],
    0,
    hometeamdf.loc[0, 'Likes'] - awayteamdf.loc[0, 'Likes'],
    hometeamdf.loc[0, 'Dislikes'] - awayteamdf.loc[0, 'Dislikes'],
    h,
    d,
    a
  ]

  global X
  X.loc[len(X)] = diff
  scaler_mm = MinMaxScaler()
  scaled_X = scaler_mm.fit_transform(X)
  return probability_model.predict(scaled_X)

h = sys.argv[1]
d = sys.argv[2]
a = sys.argv[3]
hometeam = sys.argv[4]
awayteam = sys.argv[5]

#while h != -1:
final = evaluate(h, d, a, hometeam, awayteam)
homeodds = final[len(X) - 1][0]
drawodds = final[len(X) - 1][1]
awayodds = final[len(X) - 1][2]
rethomeodds= correctodds(homeodds,drawodds,awayodds, homeodds)
retdrawodds= correctodds(homeodds,drawodds,awayodds, drawodds)
retawayodds= correctodds(homeodds,drawodds,awayodds, awayodds)
print("homeodds=",rethomeodds)
print("drawodds=",retdrawodds)
print("awayodds=",retawayodds)

