# DoodleJump
על השחקן לעבור את כל המדרגות בעזרת חיצי המקלדת בלי ליפול אחרת הוא נפסל.</br>
השחקן קופץ אוטומטית ברגע שהוא נוחת על מדרגה.</br> 
בקוד אפשר לראות שלשחקן יש Rigidbody2D דינאמי ולכן השחקן יזוז כלפי מטה וברגע שהוא נוחת על המדרגה הוא יקפוץ בחזרה מכיוון שבסקריפט Platform שנמצא בדגם Platform יש פונקציה שנקראת OnCollisionEnter2D, הפונקציה בודקת אם האובייקט האחר שנתקל בפלטפורמה מתקדם מלמטה (כלומר, הוא נופל על הפלטפורמה).
אם האובייקט האחר נופל על הפלטפורמה, הפונקציה מחפשת את הריבאונדי Rigidbody2D של האובייקט הזה ומגדירה לו מהירות עם כוח קפיצה שקבוע מראש ("jumpForce").

למשחק שלושה שלבים:
שלב ראשון: 20 מדרגות שהשחקן יצטרך לקפוץ עליהם כדי לעבור לשלב הבא.
בניית השלב נמצאת בLevelGenerator, שם בקוד מקבלים רפרנס לדגם Platform ומייצרים את מספר המדרגות בהתאם numberOfPlatforms שקיבלנו.
המדרגות שם נוצרות באופן רנדומלי עם גבולות שיתאימו ליכולות השחקן לעבור אותם. הסידור של המדרגות בשלב הזה הוא יחסית קל.
לאחר שהשחקן קופץ לעוד 2-3 מדרגות מהמדרגה הנוכחית היא מושמדת. כלומר היא לא מושמדת ישר לאחר שהשחקן מתקדם למדרגה אחרת.
ההשמדה קוראת בDestroy שנמצא בתוך Player.
לDestoy יש box collider2D שנמצא מתחת לשחקן כך שברגע שהוא מתנגש בעצם כלשהו הוא משמיד אותו. אפשר לראות זאת בסקריפט שנקרא Trigeer
בנוסף Trigger ניתן לראות בפונקציית start() שאנו שומרים את המיקום ההתחלתי של השחקן ובפונקציית הupdate() אנו בודקים אם הנקודת גובה של השחקן קטנה מנקודת ההתחלה של השחקן סימן שהוא נפל ולכן מופעלת פנוקציית restart של gameManager שבעצם טוענת את השלב מחדש. 
<img width="814" alt="Screenshot 2023-04-26 at 2 40 39" src="https://user-images.githubusercontent.com/58401645/234430884-3498e74b-8a74-4ac0-89b5-b8211b0368f9.png">



<img width="740" alt="Screenshot 2023-04-26 at 2 41 53" src="https://user-images.githubusercontent.com/58401645/234430950-0895d518-131b-4309-9f57-879315ea9c88.png">
