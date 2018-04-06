import java.io.File;  
import java.io.IOException;  
  
public class CreateKeep {  
  
    public static final String packageFile = ".keep";  
  
    public static void main(String[] args) {  
        String path = getRealPath();  
        File file = new File(path);  
        try {  
            traversalAllFolder(file);  
        } catch (Exception e) {  
            e.printStackTrace();  
        }  
    }  
  
    /** 
     * 遍历当前文件夹下的所有文件夹，对空的文件夹创建.keep文件 
     *  
     * @param dir 
     * @throws Exception 
     */  
    final static void traversalAllFolder(File dir) throws Exception {  
        File[] fs = dir.listFiles();  
        int fsLength = fs.length;  
        if (fsLength == 0) {  
            createFile(dir.getAbsolutePath());  
        } else {  
            for (int i = 0; i < fsLength; i++) {  
                if (fs[i].isDirectory()) {  
                    try {  
                        traversalAllFolder(fs[i]);  
                    } catch (Exception e) {  
                    }  
                }  
            }  
        }  
    }  
  
    /** 
     * 创建.keep文件 
     *  
     * @param folderPath 
     *            路径名 
     */  
    public static void createFile(String folderPath) {  
        String fileName = folderPath + "/" + packageFile;  
        File file = new File(fileName);  
        try {  
            file.createNewFile();  
        } catch (IOException e) {  
            e.printStackTrace();  
        }  
    }  
  
    /** 
     * 获取当前jar包所在路径 
     *  
     * @return 
     */  
    public static String getRealPath() {  
        String realPath = CreateKeep.class.getClassLoader().getResource("")  
                .getFile();  
        java.io.File file = new java.io.File(realPath);  
        realPath = file.getAbsolutePath();  
        try {  
            realPath = java.net.URLDecoder.decode(realPath, "utf-8");  
        } catch (Exception e) {  
            e.printStackTrace();  
        }  
  
        return realPath;  
    }  
  
}  