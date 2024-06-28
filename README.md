# 住民與醫囑專案 - 後端

使用 .NET 8, MongoDB

## 注意事項

目前只有在 appsettings.Development.json 加上MongoDb的連線字串，且該字串是最基本的內容，沒有包含敏感資訊，可自行修改連線字串，或直接建立無須驗證的MongoDb環境。

## 實作說明
1. Infrastructure 為建立DB的Context 與 Collection的Repository
2. Service 用來實作商務邏輯
3. Helper 用來放非商務邏輯的工具 (ex. MongoDb的Sequence increase)
4. 另外有簡單實作了 Authentication 的 middleware 與 exception handle 的 middleware，若有需要，可再實作其他機制，如log等...

## 初始資料範本
```json
[
    {
        "_id" : "1",
        "Name" : "Eden Wang",
        "OrderId" : ""
    },
    {
        "_id" : "2",
        "Name" : "Larry Lai",
        "OrderId" : ""
    },
    {
        "_id" : "3",
        "Name" : "Ellie Su",
        "OrderId" : ""
    },
    {        
        "_id" : "4",
        "Name" : "Carol Sun",
        "OrderId" : ""
    },
    {        
        "_id" : "5",
        "Name" : "Jenny Hsu",
        "OrderId" : ""
    }
]
```