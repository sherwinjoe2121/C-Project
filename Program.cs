using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace myproject
{   
    public class user
    {   
        //Decalring User id as private
        private int id;
        private int salary;
        private string name;
        private string location;

        //parameterized constructor
        public user(int id,int salary,string name,string location){
            this.id=id;
            this.salary = salary;
            this.name= name;
            this.location = location;
        }
        //using Get method for getting details
        public int getid(){return this.id;}
        public int getsalary(){return this.salary;}
        public string getname(){return this.name;}
        public string getlocation(){return this.location;}
        //Using set method to set the user details
        public void setid(int id){this.id=id;}
        public void setsalary(int salary){this.salary=salary;}
        public void setname(string name){this.name=name;}
        public void setlocation(string location){this.location=location;}
    }
    class program
    {
        
        static void Main(string[] args){
        //Declaring list and passing class user as an object
        List<user> u = new List<user>();
        Console.WriteLine("Enter the no.of user details:");
        int count=Convert.ToInt32(Console.ReadLine());
        int fl=0;
        for(int i=0;i<count;i++)
        {
            
            Console.WriteLine("Enter User id of person: ");
            int ids = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter User Name: ");
            string names = Console.ReadLine();
            Console.WriteLine("Enter User salary of person: ");
            int sal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter User Location: ");
            string loc = Console.ReadLine();
            
            user us= new user(ids,sal,names,loc);
            us.setid(ids);            
            us.setname(names);
            us.setsalary(sal);
            us.setlocation(loc);
            u.Add(us);
            if(count>i){
                Console.WriteLine("Enter Next Employee details");
            }
            
        }
        string fpath = @"D:\myproject\Program.txt";
        //var fileByteArray = ConvertToByteArray(filePath);
        if (File.Exists(fpath))
          {
            File.Delete(fpath);
          }    
                
           if(u.Count>0){
            Console.WriteLine("\n----USER DETAILS-----\n");
            
            foreach(user item in u){
                Console.WriteLine(item.getid()+"\t"+item.getname()+"\t"+item.getsalary()+"\t"+item.getlocation());

            }
            using (TextWriter wr = File.CreateText(fpath))
                {
                wr.WriteLine("\n----User ID List----");
                foreach(user item in u){
                wr.WriteLine(item.getid()+"\t"+item.getname()+"\t"+item.getsalary()+"\t"+item.getlocation());
                }
                }
           }
            else{
              Console.WriteLine("No Negative Number of users");
              fl =1;
            }
           
        
        //Using switch statement for UPDATE & DELETE
        if(fl==0){
        Console.WriteLine("Please make your selection");
        Console.WriteLine("1 Update");
        Console.WriteLine("2 Delete");
        Console.WriteLine("3 No Changes\n");

    int Selection = int.Parse( Console.ReadLine( ) );
    switch( Selection ) 
    {
        //Case 1 For Update
        case 1:
        Console.WriteLine("Enter User id to replace: ");
        int reid = Convert.ToInt32(Console.ReadLine());
        int up = 0;
        foreach(user it in u)
        {
            if(it.getid()==reid){
                up = 1;
                Console.WriteLine("Enter User id for an update:");
                int newid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter User NameFor Update: ");
                string newname = Console.ReadLine();
                Console.WriteLine("Enter User Salary for an update:");
                int newsal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter User Location for an update: ");
                string newloc = Console.ReadLine();
                it.setid(newid);
                it.setsalary(newsal);
                it.setname(newname);
                it.setlocation(newloc);
            }}
            if(up ==1){   
                Console.WriteLine("\n-----AFTER UPDATION-----\n");
                 foreach(user item in u){
                           Console.WriteLine(item.getid()+"\t"+item.getname()+"\t"+item.getsalary()+"\t"+item.getlocation());

            }    
                using (TextWriter wr = File.CreateText(fpath))
                    {
                    wr.WriteLine("\n-----After Updation-----\n");
                    foreach(user item in u){
                    wr.WriteLine(item.getid()+"\t"+item.getname()+"\t"+item.getsalary()+"\t"+item.getlocation());}
                    }
                
            }
            else{
              Console.WriteLine("No Such details");}
        break;
        //Case 2 For Delete
        case 2:
        int a= 0;
           Console.WriteLine("Enter the ID of user Delete:\n ");
           int d =Convert.ToInt32(Console.ReadLine());
           int del=0;
           foreach(user item in u){
            a++;
            if(item.getid()==d){
                del=1;
                break;
            }
           }
            u.RemoveAt(a-1);
            if(del==1){
                Console.WriteLine("\n----AFTER DELETION-----\n");
                foreach(user item in u){
                           Console.WriteLine(item.getid()+"\t"+item.getname()+"\t"+item.getsalary()+"\t"+item.getlocation());}
           using (TextWriter wr = File.CreateText(fpath))
                    {
                    wr.WriteLine("----After Deletion---\n");
                    foreach(user item in u){
                        wr.WriteLine(item.getid()+"\t"+item.getname()+"\t"+item.getsalary()+"\t"+item.getlocation());}
                    }
            }
            else
            {
            Console.WriteLine("user id doesn't exist: ");
            }
           
            break;
        case 3:
        Console.WriteLine("\n---NO CHANGES----\n");
         foreach(user item in u){
                Console.WriteLine(item.getid()+"\t"+item.getname()+"\t"+item.getsalary()+"\t"+item.getlocation());

            }
            break;           
        default:
            Console.WriteLine("Undefined Selection:");
            break;
         }
        }        
        else{
        Console.WriteLine("So Program Stops here\n");
         }
      try
      {
        using (TextReader tr = File.OpenText(fpath))
            {
            Console.WriteLine("\nReading From File");
            Console.WriteLine(tr.ReadToEnd());
            }
      }
      catch (FileNotFoundException e)
      {
        Console.WriteLine("While Reading From File: ");
        Console.WriteLine("---EXCEPTION----:{0} Because no users details are entered due to negative number of users ",e.Message);        
      }
    }
}
}