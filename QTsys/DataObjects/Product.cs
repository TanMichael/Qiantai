
namespace QTsys.DataObjects
{
    public class Product : QiaotaiObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public string Texture { get; set; }
        public string Shift { get; set; }
        public string RealShift { get; set; }
        public string Color { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }


        public string 布料编号 { get; set; }
        public string 开料要求 { get; set; }
        public string 开料尺寸 { get; set; }

        public string 胶水型号 { get; set; }
        public string 溶剂 { get; set; }
        public string 脱模剂 { get; set; }
        public string 硬化剂 { get; set; }
        public string 含浸比重 { get; set; }
        public string 搅拌时间 { get; set; }
        public string 比重计 { get; set; }
        public string 胶滚压力 { get; set; }
        public string 含浸转速HZ { get; set; }
        public string 烤箱温度C { get; set; }

        public string 成型模号 { get; set; }
        public string 成型机台 { get; set; }
        public string 手动自动 { get; set; }
        public string 单个整条 { get; set; }
        public string 成型上下模温度 { get; set; }
        public string 成型时间 { get; set; }
        public string 成型压力 { get; set; }
        public string 自动切 { get; set; }
        public string 是否拉布成型 { get; set; }
        public string 是否中孔加补强布 { get; set; }
        public string 补强布大小 { get; set; }
        public string 是否压纸板 { get; set; }
        public string 剪边喷水 { get; set; }
        public string 压定位板 { get; set; }
        public string 定型时间 { get; set; }
        public string 压纸板时间 { get; set; }

        public string 刀模 { get; set; }
        public string 中孔模 { get; set; }
        public string 刀模中心定位 { get; set; }
        public string 切刀模个数 { get; set; }
        public string 切断模 { get; set; }
        public string 切断模架 { get; set; }
        public string 切断机台 { get; set; }
        public string 单个整条切断 { get; set; }
        public string 通用气冲模 { get; set; }
        public string 气冲压力 { get; set; }
        public string 多个多条切断 { get; set; }

        public string 导线方式 { get; set; }
        public string 导线规格 { get; set; }
        public string 内留mm { get; set; }
        public string 外留mm { get; set; }
        public string 点锡长mm { get; set; }
        public string 导线长度 { get; set; }
        public string 方向数量 { get; set; }
        public string 线距mm { get; set; }
        public string 单面双面点胶 { get; set; }

        public string 胶水 { get; set; }
        public string 边胶 { get; set; }
        public string 胶水重量 { get; set; }
        public string 摆放要求 { get; set; }
        public string 工艺要求 { get; set; }
        public string 打胶方式 { get; set; }
        public string 贴合方式 { get; set; }
        public string 贴合压力 { get; set; }
        public string 贴合模具 { get; set; }
        public string 贴合机台 { get; set; }

        public string 成型首检变位 { get; set; }
        public string 生产单重 { get; set; }
        public string 样品变位 { get; set; }
        public string 样品单重 { get; set; }
        public string 测试夹具外内 { get; set; }
        public string 是否留样 { get; set; }
        public string 是否备品 { get; set; }
        public string 是否产品全检 { get; set; }
        public string 是否数量超交 { get; set; }
        public string 是否标签盖环保章 { get; set; }
        public string 备注 { get; set; }
        
    }
}
