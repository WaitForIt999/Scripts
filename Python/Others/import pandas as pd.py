import pandas as pd
import numpy as np

def load_data(file_path):
    """
    Load data from a CSV file and return a DataFrame.
    
    :param file_path: Path to the CSV file.
    :return: DataFrame containing the loaded data.
    """
     file_path: str
    
    try:
        df = pd.read_csv(file_path)
        return df
    except Exception as e:
        print(f"Error loading data: {e}")
        return None