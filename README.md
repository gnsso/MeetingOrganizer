# Meeting Organizer Web API
Toplantı planlanma ve yönetim uygulaması

# Genel Bakış
Server: ASP.NET Web API
Client: ASP.NET MVC

**GET** Kayıtlı tüm toplantıları görüntüle
> /api/meetings

**GET** Planlanmış bir toplantıyı görüntüle
> /api/meetings/1

**POST** Yeni bir toplantı planla
> /api/meetings/plan

**POST** Toplantıyı güncelle
> /api/meetings/update

**POST** Planlanan toplantıyı sil
> /api/meetings/2/delete
