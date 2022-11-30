import os
import sys
#import mkl
#mkl.domain_set_num_threads(1, domain='fft')
import pandas as pd
print("imp pd")
from tensorflow import keras
from sklearn.preprocessing import MinMaxScaler
pd.plotting.register_matplotlib_converters()
# %matplotlib inline
print("imp keras")

dateS = sys.argv[1]
dateE = sys.argv[2]

start = datetime.strptime(dateS, '%Y-%m-%d')
end = datetime.strptime(dateE, '%Y-%m-%d')

days = (end - start).days

print("Start date: ", start)
print("End date: ", end)
print("Days between: ", days)