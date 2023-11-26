namespace Exercise005
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SaveableDictionary
    {
        private Dictionary<string, string> dictionary;
        private string file;

        public SaveableDictionary()
        {
            //コンストラクタ
            this.dictionary = new Dictionary<string, string>();
        }
        
        public SaveableDictionary(string file) : this()
        {
            //コンストラクタ
            this.file = file;
        }
        
        public void Add(string words, string translation)
        {
            //辞書にワードを追加する
            //一単語につき一つの意味しか登録できない
            //すでにあるワードを登録しようとすると何も起こらないようにする
            if(!this.dictionary.ContainsKey(words) && !this.dictionary.ContainsKey(translation))
            {
                this.dictionary.Add(words,translation);
                this.dictionary.Add(translation,words);
            }
        }

        public bool Load()
        {
            // コンストラクタにパラメーターとして与えられたファイルをロードする
            // もしプログラムがファイルを開なかったら、falseを返す
            // 開たらtrueを返す
            try
            {
                string[] lines = File.ReadAllLines(this.file);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(":");
                    Add(parts[0], parts[1]);
                }
                return true;
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                return false;
            }
                
        }

        public bool Save()
        {
            // コンストラクタにパラメータとして渡されたファイルに
            // 辞書の内容を保存する
            // 正常に保存されたらtrueを返す
            // 保存できなかったらfalseを返す
            try
            {
                StreamWriter writer = new StreamWriter(this.file);
                List<string> addedWords = new List<string>();
                foreach (KeyValuePair<string, string> kvp in this.dictionary)
                {
                    if(!addedWords.Contains(kvp.Key) || !addedWords.Contains(kvp.Value))
                    {
                        addedWords.Add(kvp.Key);
                        addedWords.Add(kvp.Value);
                        writer.WriteLine(kvp.Key + ":" + kvp.Value);
                    }
                }
                writer.Close();
                return true;    
            }
            catch(Exception e)
            {
                return false;
            }
        }
        
        public string Translate(string word)
        {
            //意味を返す
            //辞書にない単語の場合はnullを返す
            if(this.dictionary.ContainsKey(word))
            {
                return this.dictionary[word];
            }
            return null;
        }

        public void Delete(string word)
        {
            //与えられたワードをキー又はバリューに含む場合
            //それを削除する
            foreach(KeyValuePair<string, string> kvp in this.dictionary)
            {
                if(kvp.Key == word || kvp.Value == word)
                {
                    this.dictionary.Remove(kvp.Key);
                }
            }

        }
    }
}
